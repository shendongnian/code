    public class ViewInvoice
    {
        public string ClientLocation { get; set; }
        public List<string> Product { get; set; }
        public List<string> ProductSize { get; set; }
        public List<string> PackageType { get; set; }
        public List<DateTime> OrderDate { get; set; }
        public List<DateTime> DeliveryDate { get; set; }
        public List<int> OrderNumber { get; set; }
        public List<decimal> Price { get; set; }
        public List<int> ItemQuantity { get; set; }
    }
