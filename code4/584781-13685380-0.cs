    public interface IBrowsableProperties
    {
       int Property1 { get;set; }
       int Property2 { get;set; }
    }
    
    public class A : IBrowsableProperties
    { 
       [Browsable(true)]
       public int Property1 { get;set; }
    
       [Browsable(true)]
       public int Property1 { get;set; }
    }
    
    public class B : IBrowsableProperties
    {
       [Browsable(false)]
       public int Property1 { get;set; }
    
       [Browsable(false)]
       public int Property1 { get;set; }
    }
    
    // Somewhere in some method...
    bool propertySelected = true;
    
    IBrowsableProperties instance = null;
    
    if(propertySelected) 
    {
       instance = new A();
    }
    else
    {
       instance = new B();
    }
    
    // ... do stuff with your instance of IBrowsableProperties!
