    public IEnumerable<MyRecord> GetFromOriginalDB()
    {
      // some fetching magic
      yield return myRecord;
    }
    
    public void WriteToTargetDB(IEnumerable<MyRecord> records)
    {
      foreach(var record in records)
      {
        // insert magic
      }
    }
