      private static void InitFileLogging(bool logDebugEvents)
        {
            string LOG_PATTERN = "%d [%t][%logger] %-5p %m%n";
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            TraceAppender tracer = new TraceAppender();
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = LOG_PATTERN;
            patternLayout.ActivateOptions();
            tracer.Layout = patternLayout;
            tracer.ActivateOptions();
            hierarchy.Root.AddAppender(tracer);
            RollingFileAppender roller = new RollingFileAppender
            {
                Layout = patternLayout,
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 4,
                MaximumFileSize = "300KB",
                StaticLogFileName = true,
                File = @"c:\temp\textLog.txt"
            };
            if (!logDebugEvents)
            {
                log4net.Filter.LevelMatchFilter debugFilter = new log4net.Filter.LevelMatchFilter() { AcceptOnMatch = false, LevelToMatch = Level.Debug };
                roller.AddFilter(debugFilter);
            }
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);
           // hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
        }
