    public class Container
    {
        [XmlElement("ElementType1", typeof(ElementType1))]
        [XmlElement("ElementType2", typeof(ElementType2))]
        public ElementBase[] Elements { get; set; }
    }
    [XmlInclude(typeof(ElementType1)),XmlInclude(typeof(ElementType2))]
    public abstract class ElementBase
    {
        public string Name { get; set; }
    }
    public class ElementType1 : ElementBase
    {
        public int ID1 { get; set; }
    }
    public class ElementType2 : ElementBase
    {
        public int ID2 { get; set; }
    }
