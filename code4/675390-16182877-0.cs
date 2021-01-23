    public IEnumerable<MyObject> ExecuteNonQuery(...)
    {
      ...
      using(var reader = comm.ExecuteReader())
      {
        var results = new List<MyObject>();
        yield return reader
                      .Cast<System.Data.Common.DbDataRecord>()
                      .Select(rec => GetFromReader(rec));
      }
    }
    
    public MyObject GetFromReader(IDataRecord rdr)
    {
       return new MyObject { Prop1 = rdr["prop1"], Prop2 = rdr["prop2"] };
    }
