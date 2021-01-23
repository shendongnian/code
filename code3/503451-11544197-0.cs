    public static class LoggingWrapper
        {
            private static ILog logger;
            private DateTime timeOfLastLog;
    
            static LoggingWrapper()
            {
                logger = LogManager.GetLogger(typeof(Program));
                logger.Info("Logger initialized");
                timeOfLastLog = DateTime.Now;
            }
    
            public static void Debug(string Message)
            {
                logger = LogManager.GetLogger("YourDebugLoggerName");
                TimeSpan differential = DateTime.Now - timeOfLastLog();
                logger.Debug(Message + "-----" + differential.ToString());
            }
        }
