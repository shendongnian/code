    [XmlType(TypeName = "classmy")]
    public class MyClass2
    {
        [XmlAttribute(AttributeName = "Items")]
        List<object> Items { get; set; } //need to change type in `<>`
        [XmlAttribute(AttributeName = "myattr")]
        public string Name { get; set; }
    }
