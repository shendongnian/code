    public class Base { }
    
    public class Derived : Base { }
    
    public Base Method() {
        return GetOtherMethod();
    }
    
    public Derived GetOtherMethod()
    {
        return new Derived ();
    }
