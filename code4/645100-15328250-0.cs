    public class ResultsCache
    {
      public IEnumerable<Visitors> TotalVisitors {get; }
      public IEnumerable<Purchases> TotalPurchases {get; }
      public IEnumerable<Refunds> TotalRefunds {get; }
    
      public void FetchData() {
         //...
      }
    }
    
    var cache24hours = new ResultsCache();
    var currentView = new RefundsView(cache24hours);
