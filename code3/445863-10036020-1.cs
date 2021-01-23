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
    private static readonly ILog log = GetLogger();
    public void LogError(LogType logtype, string message)
    {
        logtype.LogMessage(log, message);
    }
