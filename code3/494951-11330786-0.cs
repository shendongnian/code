    public class SomeIntInfo
    {
        [XmlAttribute]
        public int Value { get; set; }
    }
    
    public class SomeStringInfo
    {
        [XmlAttribute]
        public string Value { get; set; }
    }
    
    public class SomeModel
    {
        [XmlElement("SomeStringElementName")]
        public SomeStringInfo SomeString { get; set; }
    
        [XmlElement("SomeInfoElementName")]
        public SomeIntInfo SomeInfo { get; set; }
    }
