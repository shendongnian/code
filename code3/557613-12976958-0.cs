    public static class extensions()
    {
      public static NotifyAccessorSet(this string value) { some code }
    }
    public class SomeClass()
    {
      .....
      private string mAccessor;
      public string LazyAccessor{
         get { return mAccessor; }
         set { mAccessor = value; mAccessor.NotifyAccessorSet(); }
      }
    }
