    public class ProductModel 
    {
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
    }
    public class Stock
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
