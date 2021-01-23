    public class InvoiceSystem
    {
        private List<Invoice> currentOrders;
        
        public InvoiceSystem()
        {
           currentOrders = new List<Invoice>();
        }
        public void Populate()
        {
            //fill your list from the database
        }
        public void Save()
        {
           //Save list back to database
        }
        public List<Invoice> GetInvoices(/*perhaps something to filter */ )
        {
             // return filtered list, or entire list.
        }
        public decimal GetTotalForYear(int year)
        { 
            // iterate through list (or use linq) to get total and return it
        }
    }
    public class Invoice
    {
        public int      InvoiceID { get; set; }
        public string   Employee { get; set; }
        public string   Store { get; set; }
        public string   Client { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal  Total { get; set; }
    }
