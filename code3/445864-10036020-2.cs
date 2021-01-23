    public abstract class LogType
    {
        public static readonly LogType Debug = new LogTypeDebug();
        public static readonly LogType Error = new LogTypeError();
        private LogType() {} // Prevent anyone else from making one.
        public abstract void LogMessage(ILog logger, string message);
        private sealed class LogTypeDebug: LogType
        {
            public override void LogMessage(ILog logger, string message)
            {
                logger.Debug(message);
            }
        }
        private sealed class LogTypeError: LogType
        {
            public override void LogMessage(ILog logger, string message)
            {
                logger.Error(message);
            }
        }
    }
    ...
    //Obtain the log object the way you prefer.
    private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public void LogError(LogType logtype, string message)
    {
        logtype.LogMessage(log, message);
    }
