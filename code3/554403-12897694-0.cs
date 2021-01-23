    class Pair<T> where T : struct {
    
      public Pair(T? a, T? b) {
        A = a;
        B = b;
      }
    
      public T? A { get; private set; }
    
      public T? B { get; private set; }
    
    }
    
    void DoSomething<T>(Pair<T> pair) where T : struct {
      DoMore(pair);
    }
    
    void DoMore(params object[] args) {
      Console.WriteLine("Do more");
      var nullableIntPairs = args.Where(IsNullableIntPair);
      foreach (Pair<int> pair in nullableIntPairs) {
        Console.WriteLine(pair.A);
        Console.WriteLine(pair.B);
      }
    }
    
    bool IsNullableIntPair(object arg) {
      var type = arg.GetType();
      return type.IsGenericType
        && type.GetGenericTypeDefinition() == typeof(Pair<>)
        && type.GetGenericArguments()[0] == typeof(int);
    }
