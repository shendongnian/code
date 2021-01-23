    public class Base
    {
      //I am virtual, this means that I can be overriden
      public virtual void MethodA()
      {
        Console.WriteLine("Hello, From Base");
      }
    }
    public class Derived : Base
    {
      //I am Base, but with other stuff.
    
      //I am going to do something else with MethodA
      public override void MethodA()
      {
        Console.WriteLine("Hello, From Derived");
      }
    }
