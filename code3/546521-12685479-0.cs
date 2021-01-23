    public class Base
    {
      public int GetValue1()
      {
        return 1;
      }
      
      public virtual int GetValue2()
      {
        return 2;
      }
    }
    
    public class Derived : Base
    {
      public int GetValue1()
      {
        return 11;
      }
    
      public override int GetValue2()
      {
         return 22;
       }
    }
    Base a = new A();
    Base b = new B();
    
    b.GetValue1();   // prints 1
    b.GetValue2();   // prints 11 
