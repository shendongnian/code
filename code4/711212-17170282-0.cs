    [XmlType("item")]
    public class Item
    {
        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
