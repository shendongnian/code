    public class InvoicingAddress : PostalAddress
    {
        //...
        public int PostId { get; set; }
        public virtual Post Post { get; private set; }
    }
