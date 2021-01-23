    public class Product
    {
        public Guid ProductId { get; set; }
        [Required]
        public Category Category { get; set; }
    }
