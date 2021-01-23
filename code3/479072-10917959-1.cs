    public class ProductSearch
    {
        public ProductSearch()
        {
            q = string.Empty;
            Product1 = new Product();
            Product2 = new Product();
        }
        public string q { get; set; }
        public Product Product1 { get; set; }
        public Product Product2 { get; set; }
    }
