    public class AlertItem
    {
        [XmlElement(ElementName = "docketNumber")]
        public string DocketNumber { get; set; }
        [XmlElement(ElementName = "dotNumber")]
        public string DOTNumber { get; set; }
        [XmlElement("Change")]
        public List<Change> Changes {get; set;}
    }
    public class Change
    {
        [XmlElement("Field")]
        public string Field {get; set;}
        [XmlElement("From")]
        public string From {get; set;}
        [XmlElement("To")]
        public string To {get; set;}
    }
