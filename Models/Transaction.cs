using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key] 
        public int TransactionId { get; set; }

        //CatogeryId
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; }
        public Category Catogery { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }



        [Column(TypeName = "nvarchar(75")]
        public String? Note { get; set; }



        public DateTime Date { get; set;} = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Catogery == null ? "" : Catogery.Icon + " " + Catogery.Title;
            }
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Catogery == null || Catogery.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }

    }
}
