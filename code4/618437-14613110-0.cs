    public LogViewModel(ILogServiceAgent sa)
    public interface ILogServiceAgent
    {
        FetchLog(DateTime startDate, DateTime endDate)
    }
    
    public SqlLogFetcher : ILogServiceAgent
    {
       FetchLog(DateTime startDate, DateTime, endDate)
       {
           //Fetch SQL log implementation
       }
    }
    public WebServiceLogFetcher : ILogServiceAgent
    {
       FetchLog(DateTime startDate, DateTime, endDate)
       {
           //Web service log implementation
       }
    }
