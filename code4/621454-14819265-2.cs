    public class Order
    {
        public int OrderId { get; set; }
        public virtual Quotation Quotation { get; set; }
    }
    public class Quotation
    {
        public int QuotationId { get; set; }
        public virtual Order Order { get; set; }
    }
