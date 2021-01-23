    public struct MyNullable<T> {
      public T value;
      public bool hasValue;
    }
    
    struct info { 
      public float a, b;
      public MyNullable<info> next;
    }
