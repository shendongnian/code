    public class MainClass
    {
        [XmlElement(Type = typeof(ClassA))]
        [XmlElement(Type = typeof(ClassB))]
        [XmlElement(Type = typeof(ClassC))]
        public ClassA A;
    }
