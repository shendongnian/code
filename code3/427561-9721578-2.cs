    public class MyLogger : System.Web.Http.Common.ILogger
    {
        public void LogException(string category, TraceLevel level, Exception exception)
        {
            // Do some logging here eg. you could use log4net
        }
        public void Log(string category, TraceLevel level, Func<string> messageCallback)
        {
            // Do some logging here eg. you could use log4net
        }
    }
