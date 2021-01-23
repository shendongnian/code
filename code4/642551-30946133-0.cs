    public static class LoggerExtensions
    {
        public static void LogError(this ILoggerFacade logger, string message, [CallerMemberName] string caller = "")
        {
            logger.Log(message + ' ' + caller, Category.Exception, Priority.High);
        }
    }
