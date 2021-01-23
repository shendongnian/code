    public class InvoiceCollection : List<Invoice> { }
    public class Customer {
        public string name { get; set; }
        InvoiceCollection invoices { get; set; }
    }
        
