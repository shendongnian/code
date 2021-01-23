    //[XmlRoot(ElementName = "Root")]
    [YAXSerializeAs("Root")]
    public class TopLevel
    {
        public string topLevelProperty { get; set; }
        public NestedObject nestedObj { get; set; }
    }
    public class NestedObject
    {
        [YAXElementFor("..")]
        string propetyOnNestedObject { get; set; }
    }
