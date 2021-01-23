    public IEnumerable<MyClass> GetObjects() 
    {
      IDataReader dr = GetSomeDataReader();
      return ProcessReader(dr, CloseDBConnections);
    }
    public IEnumerable<MyClass> ProcessReader(IDataReader dr, Action OnFinished)
    {
      while (dr.Read())
      {
        yield return new MyClass(dr);
      }
      OnFinished();
    }
