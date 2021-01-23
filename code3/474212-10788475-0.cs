    public class A
    {
      public virtual void Foo()
      {
        Console.WriteLine("A.Foo() called");
      }
    }
    
    public class B: A
    {
      public override void Foo()
      {
        Console.WriteLine("B.Foo() called");
      }
    }
    
    void Main()
    {
    new B().Foo();
    }
