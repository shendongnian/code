    public static class LoggerFactory
    {
        public static ILogger Logger
        {
            get
            {
                return LoggerFactory._logger == null ? new Logger() : LoggerFactory._logger;
            }
            set
            {
                LoggerFactory._logger = value;
            }
        }
        private static ILogger _logger = null;
    }
