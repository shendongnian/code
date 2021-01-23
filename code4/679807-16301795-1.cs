     private static void DisableDebugFileLogging()
        {
            XmlConfigurator.Configure();
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            foreach (var appender in hierarchy.GetAppenders())
            {
                RollingFileAppender rolAppender = appender as RollingFileAppender; //or whatever appender you use
                if (rolAppender != null)
                {
                    log4net.Filter.LevelMatchFilter debugFilter = new log4net.Filter.LevelMatchFilter() { AcceptOnMatch = false, LevelToMatch = Level.Debug };
                    rolAppender.AddFilter(debugFilter);
                }
                rolAppender.ActivateOptions();
            }
        }
