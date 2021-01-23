    public class Quote
    {
        [XmlElement("author")]
        public string author { get; set; }
        [XmlElement("text")]
        public List<string> text { get; set; }
    }
