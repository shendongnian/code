    public MarketData
    {
      public int SlNo { get; set; }
      public string SubSystemType { get; set; }
      ...
    }
    
    // in the queries:
    select new MarketData
    {
      SlNo = objDataTable.Rows.IndexOf(dr) + 1,
      ...
    }
