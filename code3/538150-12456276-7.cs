    public interface IAggregationView
    {
       DataTable SetSiteData { set; }
    }
    
    class AggregationViewImp : IAggregationView
    {
       public DataTable SetSiteData { get; set; }  // perfectly OK
    }
