    public IEnumerable<MyClass> GetObjects() 
    {
      return ProcessReader(GetSomeDataReader(), CloseDBConnections);
    }
    public IEnumerable<MyClass> ProcessReader(IDataReader dr, Action OnFinished)
    {
      try
      {
        while (dr.Read())
          yield return new MyClass(dr);
      }
      finally
      {
        if (OnFinished != null) 
          OnFinished();
      }
    }
