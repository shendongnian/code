    public class Enclosure
    {
        [XmlElement("url")]
        public string url { get; set; }
    }
    public class Evento
    {
        [XmlElement("title")]
        public string title { get; set; }
        [XmlElement("enclosure")]
        public Enclosure image { get; set; }
        [XmlElement("description")]
        public string description { get; set; }
    }
