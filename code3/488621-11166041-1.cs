    [Serializable]
    public class MyType
    {
        [XmlElement(ElementName="MyType")]
        public List<MyType> Types { get; set; }
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }
    }
