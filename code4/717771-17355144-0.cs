    public class Product
    {
        public string productId { get; set; }
        public string brandId { get; set; }
        public string departmentId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
    public class Data
    {
        public string dailyDealId { get; set; }
        public string discountPercentage { get; set; }
        public Product product { get; set; }
    }
    
