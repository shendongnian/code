    class Base 
    {
      public Derived Property1 {get;set;}
      public Base Property2 {get;set;}      
      public static Base Create()
      {
        return new Derived();
      }
      public static Derived Create2()
      {
        return new Derived();
      }
    }
    
    class Derived : Base
    {
    }
