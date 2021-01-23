    [XmlRoot("list")]
    public class GroceryList
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("author")]
        public string Author { get; set; }
    
        [XmlAttribute("desc")]
        public string Description { get; set; }
    
        [XmlElement("item")]
        public Item[] Items { get; set; }
    }
    
    public class Item
    {
        [XmlAttribute("color")]
        public string Color { get; set; }
    
        [XmlAttribute("done")]
        public bool Done { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
