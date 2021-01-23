    class HashRunningTotalDB : IEnumerable<KeyValuePair<int, SummaryEntity>>
    {
       Dictionary<int, SummaryEntity> thisHashRunningTotalDB = new Dictionary<int, SummaryEntity>();
       public IEnumerator<KeyValuePair<int, SummaryEntity>> GetEnumerator()
       {
          return thisHashRunningTotalDB.GetEnumerator();
       }
       IEnumerator IEnumerable.GetEnumerator()
       {
          return GetEnumerator();
       }
    }
    static void Main ()
    {
       HashRunningTotalDB  tempDB = new HashRunningTotalDB();
       // should work now
       foreach(KeyValuePair<int, SummaryEntity> item in tempDB)
       {
           Console.Writeline(item.Key + " " + item.Value.SomeProperty);
       }
    }
