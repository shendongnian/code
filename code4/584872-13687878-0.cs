    public class Product
    {
        public Cycle Cycle { get; set; }
        public Brand Brand { get; set; }
        public List<Item> Updates { get; set; }
    }
    
    public class Cycle
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }
    
    }
    
    public class Brand
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("Include")]
        public string Include { get; set; }
    }
    
    public class Item
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlElement("Artifact")]
        public List<Artifact> Artifacts { get; set; }
    }
    
    public class Artifact
    {
        [XmlAttribute("Kind")]
        public int Kind { get; set; }
        [XmlAttribute("Action")]
        public int Action { get; set; }
    }
