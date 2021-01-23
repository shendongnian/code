    [DataContract]
    public class Invoice
    {
        [DataMember]
        public string InvoiceNum { get; set; }
        [DataMember]
        public DateTime InvoiceDate { get; set; }
        [DataMember]
        public decimal InvoiceTotal { get; set; }
        [DataMember]
        public string Job { get; set; }
    }
