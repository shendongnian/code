    void Main()
    {
      Base.StaticMethod(); // should return "Base"
      Derived.StaticMethod();  // should return "Derived"
    }
    
    
    class Base
    {
      public static void StaticMethod()
      {
        Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.Name);
      }
    }
    
    class Derived: Base 
    {
    }
