    public class MyClass<T>
    {
      #region ctors
      public MyClass()
      {
        this.UniqueData = new HashSet<T>();
      }
      #endregion
      public HashSet<T> UniqueData { get; private set; } 
    }
