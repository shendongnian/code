    public class ExpenseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Limit { get; set; }
        public int UserProfileId { get; set; }
    }
