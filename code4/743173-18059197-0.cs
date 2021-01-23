    public class ServerConfig
    {
        public ServerConfig()
        {
            Items = new List<Item>();
        }
    
        [XmlAttribute("type")]
        public string Type { get; set; }
        
        [XmlAttribute("version")]
        public string Version { get; set; }
        
        [XmlAttribute("createDate")]
        public DateTime CreateDate { get; set; }
        
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Item> Items { get; set; }
    }
    
    public class Item
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("type")]
        public string Type { get; set; }
        
        [XmlAttribute("source")]
        public string Source { get; set; }
        
        [XmlAttribute("destination")]
        public string Destination { get; set; }
        
        [XmlAttribute("action")]
        public string Action { get; set; }
    }
