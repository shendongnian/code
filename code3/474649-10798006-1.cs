    public class OrderConfirm
    {
        public ICollection<QuoteLine> SalesLines { get; set; }
        public string Currency { get; set; }
        public int EnquiryID { get; set; }
        public SelectList LostReasons { get; set; }
    }
