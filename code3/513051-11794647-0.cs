    [XmlType("link")]
    public class LinkFinalVersion
    {
        [XmlAttribute("href")]
        public string Url { get; set; }
        [XmlAttribute("rel")]
        public string Relationship { get; set; }
    }
