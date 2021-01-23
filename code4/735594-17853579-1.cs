    public IEnumerable<MyClass> GetObjects() 
    {
      return ProcessReader(GetSomeDataReader(), CloseDBConnections);
    }
    public IEnumerable<MyClass> ProcessReader(IDataReader dr, Action OnFinished)
    {
      while (dr.Read())
        yield return new MyClass(dr);
      
      if (OnFinished != null) 
        OnFinished();
    }
