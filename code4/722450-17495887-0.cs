    public class Model
    {
        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$",ErrorMessage = "You didn't enter a decimal!")]
        public decimal Cost { get;set; }
    }
