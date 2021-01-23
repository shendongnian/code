    public class Foo
    {
        public string FooName{get;set;}
        [XmlElement("Bar")]
        public List<Bar> Bars{get;set;}
    }
