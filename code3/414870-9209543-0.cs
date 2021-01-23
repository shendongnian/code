    [XmlRoot("ChartXml")]
    public class ChartXml
    {
        [XmlElement("Category")]
        public Category Category;
    }
    
    public class Category
    {
        [XmlAttribute("type")]
        public string Type;
    
        [XmlElement("Value")]
        public List<string> Values;
    }
