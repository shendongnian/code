    public abstract class ElementBase
    {
    }
    public class ElementOne : ElementBase
    {
    }
    public class ElementTwo : ElementBase
    {
        public SubElementList SubElements { get; set; }
    }
    public class SubElementList
    {
        [XmlElement("element-one", typeof(ElementOne))]
        [XmlElement("element-two", typeof(ElementTwo))]
        public ElementBase[] Items { get; set; }
    }
    [XmlRoot("root-element")]
    public class RootElement
    {
        public SubElementList SubElements { get; set; }
    }
