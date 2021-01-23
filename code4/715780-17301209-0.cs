    [Serializable]
    [XmlRoot("RootNode")] 
    public class Example
    {
        [XmlElement("Foo")]
        public string Foo { get; set; }
        [XmlElement("Bar")]
        public string Bar { get; set; }
    }
