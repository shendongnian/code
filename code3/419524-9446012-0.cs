    [XmlType(TypeName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "updated")]
        public DateTime? Updated { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "link")]
        public Link Link { get; set; }
        [XmlElement(ElementName = "entry")]
        public List<Entry> Entries { get; set; }
        public Feed()
        {
            Entries = new List<Entry>();
        }
    }
    public class Entry
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "updated")]
        public DateTime? Updated { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "link")]
        public Link Link { get; set; }
        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }
    }
    public class Link
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }
