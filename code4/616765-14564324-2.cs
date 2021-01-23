    [XmlType("Document")]
    public class DocBalanceItem
    {
        [XmlElement("Id")]
        public Guid DocId { get; set; }
    
        [XmlElement("Balance")]
        public decimal? BalanceAmount { get; set; }
    }
