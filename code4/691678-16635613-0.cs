    public class ReportInfo
    {
        public DateTime Date { get; set; }
        public string BillNumber { get; set; }
        public string Address { get; set; }
        public string BillAddress { get; set; }
        public string BillOwner { get; set; }
        public string TaxNumberIDNumber { get; set; }
        public string PaymentType { get; set; }
        public string MoneyWithText { get; set; }
        public int OrderId { get; set; }
    }
    public class ReportProduct
    {                          
        public string ProductInfo { get; set; }
        public double Amount { get; set; }
        public string ProductCode { get; set; }
        public double Tax { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
        
    }
    
