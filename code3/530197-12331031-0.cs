    public class Product
    {
        public int ProductID { get; set; }
        public ICollection<Product> RelatedProducts { get; set; }
    }
