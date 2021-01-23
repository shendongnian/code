    public class TestClass<T>
    {
      static T TrueIfBoolean = typeof(T) == typeof(bool) ? (T)(object)true : default(T)
      
      public T TestMethod()
      {
        return TrueIfBoolean;
      }
    }
