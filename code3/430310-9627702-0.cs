    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        [XmlElement("subtitle")]
        public string Subtitle { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("entry")]
        public Entry[] Entries { get; set; }
        public class Entry
        {
            [XmlElement("title")]
            public string Title { get; set; }
            [XmlElement("summary")]
            public string Summary { get; set; }
            [XmlElement("content")]
            public string Content { get; set; }
            [XmlElement("published")]
            public DateTime Published { get; set; }
            [XmlElement("updated")]
            public DateTime Updated { get; set; }
        }
    }
