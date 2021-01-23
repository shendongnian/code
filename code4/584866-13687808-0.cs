    [Serializable]
    [XmlRoot("Product")]
    public class Product
    {
        [XmlElement("Cycle")]
        public Cycle Cycle { get; set; }
        [XmlElement("Updates")]
        public Updates Updates { get; set; }
        public Product()
        {
            Cycle = new Cycle();
            Updates = new Updates();
        }
    }
    [Serializable]
    public class Cycle
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }
    }
    [Serializable]
    public class Updates
    {
        [XmlElement("Item")]
        public List<Item> Items { get; set; }
        public Updates()
        {
            Items = new List<Item>();
        }
    }
    [Serializable]
    public class Item
    {
        [XmlElement("Artifact", typeof(Artifact))]
        public List<Artifact> Artifacts { get; set; }
        public Item()
        {
            Artifacts = new List<Artifact>();
        }
    }
    [Serializable]
    public class Artifact
    {
        [XmlAttribute("Kind")]
        public int Kind { get; set; }
    }
