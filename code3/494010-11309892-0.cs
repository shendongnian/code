    public class SomeClass : IB
    {
      public MyClass<IA> SomeGetter
      {
        get { return new MyClass<A>(); }
      }
    }
