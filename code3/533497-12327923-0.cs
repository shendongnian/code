    public void Sample<T>(T i, object o)
    {
      Type t = typeof(T);
      if (i != null)
      {
        t = i.GetType();
      }
    
      // Do whatever with t
      Console.WriteLine(t);
    }
