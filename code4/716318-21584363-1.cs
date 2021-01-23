    /// <summary>
    /// Set up the Enterprise logging class
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Define the logging parameters
        /// </summary>
        public static void DefineLogger()
        {
            var builder = new ConfigurationSourceBuilder();
            string loggerPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            builder.ConfigureLogging()
                   .WithOptions
                     .DoNotRevertImpersonation()
                   .LogToCategoryNamed("LogWriter")
                   .WithOptions.SetAsDefaultCategory()
                     .SendTo.RollingFile("Rolling Flat File Trace Listener")
                     .RollAfterSize(1000)
                       .FormatWith(new FormatterBuilder()
                         .TextFormatterNamed("Text Formatter")
                           .UsingTemplate(@"Timestamp: {timestamp}{newline}Message: {message},{newline}Category: {category},{newline}Severity: {severity},{newline}Title:{title},{newline}ProcessId: {localProcessId},{newline}Process Name: {localProcessName},{newline}Thread Name: {threadName}"))
                           .ToFile(loggerPath + Properties.Settings.Default.LogFileFolder);
            // Reference app.config
            using (DictionaryConfigurationSource configSource = new DictionaryConfigurationSource())
            {
                builder.UpdateConfigurationWithReplace(configSource);
                LogWriterFactory logWriterFactory = new LogWriterFactory(configSource);
                Logger.SetLogWriter(new LogWriterFactory(configSource).Create());
            }
        }
    }
