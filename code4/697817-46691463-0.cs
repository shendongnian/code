    public static class Log4NetTestHelper
    {
        public static string[] RecordLog(Action action)
        {
            if (!LogManager.GetRepository().Configured)
                BasicConfigurator.Configure();
            var logMessages = new List<string>();
            var root = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root;
            var attachable = root as IAppenderAttachable;
    
            var appender = new MemoryAppender();
            if (attachable != null)
                attachable.AddAppender(appender);
    
            try
            {           
                action();
            }
            finally
            {
                var loggingEvents = appender.GetEvents();
                foreach (var loggingEvent in loggingEvents)
                {
                    var stringWriter = new StringWriter();
                    loggingEvent.WriteRenderedMessage(stringWriter);
                    logMessages.Add(string.Format("{0} - {1} | {2}", loggingEvent.Level.DisplayName, loggingEvent.LoggerName, stringWriter.ToString()));
                }
                if (attachable != null)
                    attachable.RemoveAppender(appender);
            }
    
            return logMessages.ToArray();
        }
    }
