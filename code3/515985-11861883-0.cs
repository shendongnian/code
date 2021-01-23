        [XmlType(TypeName = "classmy")]
        public class MyClass2
        {
            [XmlElement(ElementName = "Items")]
            public object[] Items { get; set; }
            [XmlAttribute(AttributeName = "myattr")]
            public string Name { get; set; }
        }
