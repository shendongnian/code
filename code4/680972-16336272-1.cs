    public class SellStatement
    {
        List<string> _productName = new List<string>();
        List<double> _quantity = new List<double>();
        List<double> _ratePerQuantity = new List<double>();
        public long billNo {get; set;}
        public DateTime paymentDate  {get; set;}
        public List<string> ProductName { get { return _productName; } }
        public List<double> quantity { get { return _quantity; } }
        public List<double> ratePerQuantity { get { return _ratePerQuantity; } }
    }
