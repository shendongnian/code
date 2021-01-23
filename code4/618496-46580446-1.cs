    public class Base
    {
        public string BaseField;
    }
    
    public class Derived : Base
    {
        public string DerivedField;
    }
    
    Base base = new Base();
    //some alother code
    Derived derived = new Derived();
    CloneObjectWithIL(base, derived);
