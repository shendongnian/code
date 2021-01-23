    public interface IFoo   // corresponds to IEnumerable
    {
      IBar GetBar();
    }
    public interface IBar   // corresponds to IEnumerator
    {
    }
    public class Foo : IFoo
    {
      // public method that has BarInternal as return type
      public BarInternal GetBar()
      {
        return new BarInternal();
      }
      // explicit interface implementation which calls the public method above
      IBar IFoo.GetBar()
      {
        return GetBar();
      }
      public struct BarInternal : IBar
      {
      }
    }
