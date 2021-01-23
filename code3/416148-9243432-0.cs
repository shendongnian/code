    public class TotalViewsPerId
    {
      public int Id {get;set;}
      public int TotalViews {get;set;}
    }
    
    List<TotalViewsPerId> response = ExecuteRequest(uri)
                                  .Select(d => new TotalViewsPerId{d.Id, d.TotalViews })
                                  .ToList();
