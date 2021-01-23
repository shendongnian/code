    [XmlRoot(ElementName="ExampleCol")]
    public class Test
    {
        [XmlElement("ElementWithAttribute")]
        public ElementWithAttribute Element = new ElementWithAttribute();
        [XmlArray(ElementName="AnotherCol")]
        public List<Row> AnotherCol = new List<Row>();
        public Test()
        {
        }
    }
    public class ElementWithAttribute
    {
        public ElementWithAttribute()
        {
        }
        [XmlAttribute]
        public string attr { get; set; }
        [XmlText]
        public string value { get; set; }
    }
    public class Row
    {
        public Row()
        {
        }
        [XmlAttribute]
        public string attr { get; set; }
        [XmlText]
        public string value { get; set; }
    }
