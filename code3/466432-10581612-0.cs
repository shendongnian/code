    static class ValueFor<T>
    {
      // you get another field per type T
      public static X X { get; private set; }
    
      internal static SetUpValue(X value) { X = value; }
    }
