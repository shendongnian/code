    [XmlType("Access")]
    public class Access
    {
       [XmlElement("Phone")]
       public AccessItem Phone { get; set; }
    
       [XmlElement("Computer")]
       public AccessItem Computer { get; set; }
    }
    
    public class AccessItem
    {
        public AccessItem()
        {
            Items = new List<Item>();
        }
    
        [XmlAttribute("hasTextField")]
        public bool HasTextField { get; set; }
    
        [XmlElement("Item")]
        public List<Item> Items { get; set; }
    }
    
    [XmlType("Item")]
    public class Item
    {
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
