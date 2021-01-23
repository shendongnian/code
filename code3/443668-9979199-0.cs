    [XmlInclude(typeof(Derived))]
    public class Base
    {
    }
    
    [XmlType("Fred")]
    public class Derived : Base
    {
    }
