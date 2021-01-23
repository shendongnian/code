    public class Product
    {
        [XmlAttribute()]
        public long Id { get; set; }
        [XmlAttribute()]
        public string Description { get; set; }
        [XmlAttribute()]
        public string NonRefundable { get; set; }
        [XmlAttribute()]
        public string StartDate { get; set; }
        [XmlAttribute()]
        public string EndDate { get; set; }
        [XmlAttribute()]
        public decimal Rate { get; set; }
        [XmlAttribute()]
        public bool Minstay { get; set; }
    }
