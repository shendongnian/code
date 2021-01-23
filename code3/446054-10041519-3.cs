    public static class LoggingHelper
    {
        public static ILog GlobalLogger
        {
            get { return _globalLogger; }
        }
        private static ILog _globalLogger = log4net.LogManager.GetLogger("Global"); 
    }
