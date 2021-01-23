    [XmlInclude(typeof(Person))]
    [XmlInclude(typeof(Other))]
    public class SomeList
    {
        public object obj;
    }
    
    public class Person
    {
        public string first;
        public string last;
    }
    
    public class Other
    {
        public int MyProperty { get; set; }
    }
