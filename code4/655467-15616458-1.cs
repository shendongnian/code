    public class Response
    {
        [XmlElement("ReturnCode")]
        public int ReturnCode { get; set; }
    
        [XmlIgnore()]
        public string Line { get; set; }
    }
