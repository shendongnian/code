    public class Hello
    {
        public Person Person { get; set; }
    }
    public class Person
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Saying { get; set; }
    }
