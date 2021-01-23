    public class InvoiceNumberSequence { 
        public string Prefix { get; set; }
        public int Number { get; set; }
    
        public string Sequence {
            get { retrun Prefix + Number; }
            set { // Add your parsing logic }
        }
    }
