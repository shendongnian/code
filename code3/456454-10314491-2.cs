    public static class LoggerExtensions
    {
        public static void Debug(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(message)
            {
                Severity = LoggingSeverity.Debug,
            });
        }
        public static void Info(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(message)
            {
                Severity = LoggingSeverity.Information,
            });
        }
    }
