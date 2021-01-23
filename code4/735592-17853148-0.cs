    public IEnumerable<MyClass> GetObjects() 
    {
      IDataReader dr = GetSomeDataReader();
      try
      {
        foreach (var result in ProcessReader(dr))
        {
          yield return result;
        }
      } finally {
        CloseDBConnections();
      }
    }
