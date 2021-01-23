    public class Parent
    {
        [XmlElement(Type = typeof(Girl))]
        [XmlElement(Type = typeof(Boy))]
        public IChild Child { get; set; }
    }
