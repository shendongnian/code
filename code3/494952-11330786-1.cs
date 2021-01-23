    public class SomeInfo<T>
    {
        [XmlAttribute]
        public T Value { get; set; }
    }
    
    public class SomeModel
    {
        [XmlElement("SomeStringElementName")]
        public SomeInfo<string> SomeString { get; set; }
    
        [XmlElement("SomeInfoElementName")]
        public SomeInfo<int> SomeInfo { get; set; }
    }
