    public static class LogToFile
    {
        public const string RollingFileLoggerName = "RollingFileLogger";
        public const string RollingFileAppenderName = "rollingFileAppender";
        private static readonly ILog Logger = LogManager.GetLogger(RollingFileLoggerName);
        /// <summary>
        /// Logs to log4net rollingFileAppender
        /// </summary>
        /// <param name="fileNameBase">prefix of log filename</param>
        /// <param name="message">log4net message property</param>
        /// <param name="context">files grouped by context</param>
        public static void Log(string fileNameBase, string message, string context)
        {
            if (fileNameBase == null) throw new ArgumentNullException("fileNameBase");
            if (message == null) throw new ArgumentNullException("message");
            if (context == null) throw new ArgumentNullException("context");
            string fileName = string.Format("{0}_{1}.log", fileNameBase, context);
            string fullFileName = Path.Combine(Properties.Settings.Default.LogFilePath, fileName);
            if (!Directory.Exists(Properties.Settings.Default.LogFilePath)) Directory.CreateDirectory(Properties.Settings.Default.LogFilePath);
            ActivateAppenderOptions(string.Format(fullFileName));
            Logger.Info(message);
        }
        /// <summary>
        /// Update the appender in log4net after setting the log file path
        /// </summary>
        /// <param name="filename"></param>
        private static void ActivateAppenderOptions(string filename)
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            var appenders = hierarchy.GetAppenders();
            foreach (
                var rfa in appenders.OfType<RollingFileAppender>().Where(rfa => rfa.Name == RollingFileAppenderName))
            {
                rfa.File = filename;
                rfa.ActivateOptions();
            }
        }
    }
