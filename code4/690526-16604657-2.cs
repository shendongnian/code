    public class Foo : IFoo
    {
      // public method that directly implements the interface
      public IBar GetBar()
      {
        return new BarInternal();
      }
      public struct BarInternal : IBar
      {
      }
    }
