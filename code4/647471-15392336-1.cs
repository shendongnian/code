    public interface Ic
    {
        int Type { get; }
        string Name { get; }
    }
    public class A : Ic
    {
         .
         .
         .
    }
    public class B : Ic
         .
         .
         .
    }
    
    public Ic func(bool flag)
    {
         if (flag)
             return new A();
           return new B();
    
    }
