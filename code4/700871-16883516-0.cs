    public class item {
        [XmlElement("thumbnail")]
        public thumbnail thumbnail {get;set;}
    }
    
    public class thumbnail
    {
        [XmlElement("U=url")]
        public string url { get; set; }
    
        [XmlElement("width")]
        public string width { get; set; }
    
        [XmlElement("height")]
        public string height { get; set; }
     }
