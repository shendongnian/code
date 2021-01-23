    public class Items
    {
        [XmlAttribute("id")]
        public string ID { get; set; }
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("word")]
        public List<string> Words { get; set; }
    }
    [XmlRoot("root")]
    public class Lists
    {
        [XmlElement("list")]
        public List<Items> Get { get; set; }
    }
