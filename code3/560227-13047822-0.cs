    public class X {
        public string Name { get; set; }
        [XmlArray(ElementName = "ArrayOfY")]
        public List<Y> Y { get; set; }
    }
