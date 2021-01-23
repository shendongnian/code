    void DoSomethingWithDisposable<T,U>(ref T p1, 
         List<int>.Enumerator p2) where T:IDisposable
    {
      IDisposable v1a = p1; // Coerced
      Object v1b = p1; // Coerced
      IDisposable v2a = (IDisposable)p2; // Cast
      Object v2b = (Object)p2; // Cast
      p1.Dispose(); // Constrained call
    }
    void blah( List<string>.Enumerator p1, List<int>.Enumerator p2) // These are value types
    {
      DoSomethingWithDisposable(p1,p2); // Constrains p1 to IDisposable
    }
