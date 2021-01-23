    abstract class Base : IMethod
    {
      void IMethod.DoWork()
      {
        DoWork();
      }
      protected virtual void DoWork()
      {
        Console.WriteLine("Base.DoWork");
      }
    }
    class Derived : Base
    {
      protected override void DoWork()
      {
        base.DoWork();
        //here I where I want to call base.DoWork();
        Console.WriteLine("Derived.DoWork");
      }
    }
