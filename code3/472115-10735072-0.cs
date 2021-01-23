    public class Parent
    {
        [XmlElement("Child1")]
        public string Child1 { get; set; }
        [XmlElement("Child2")]
        public string Child2 { get; set; }
        public bool ShouldSerializeChild2() { return true; }
    }
