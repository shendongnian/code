    class BaseClass 
    { 
      public virtual void SomeMethod() 
      {
        Console.WriteLine("In base class");
      }
    }
    class Derived : BaseClass
    { 
      public override void SomeMethod() 
      {
        Console.WriteLine("In derived class");
      }
    }
