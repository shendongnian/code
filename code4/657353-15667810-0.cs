    public class ProductViewModel : IProduct
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public DateTime DateAdded { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
    }
