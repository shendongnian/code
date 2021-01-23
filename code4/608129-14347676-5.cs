    [XmlRoot("dc", Namespace= dc.NS_DC)]
    public class DCItem 
    {
        [XmlElement("books")]
        public Books Books { get; set; }
    }
