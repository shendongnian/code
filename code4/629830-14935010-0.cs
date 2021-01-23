    public class Base
    {
        public int Foo { get; set; }
    }
    
    public class Derived : Base
    {
        public int Bar { get; set; }
    }
    
    Derived d = new Base();
