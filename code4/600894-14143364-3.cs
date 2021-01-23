    [XmlRoot("examples")]
    public class ExampleWrapper // Not a collection!
    {
        [XmlElement("example")]
        public List<Example> innerList;
    }
