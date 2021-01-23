      public class MyLogger
      {
        public MyLogger(Logger logger)
        {
          _logger = logger;
        }
        private Logger _logger;
        private void WriteMessage(LogLevel level, string message)
        {
          //
          // Build LogEvent here...
          //
          LogEventInfo logEvent = new LogEventInfo(logLevel, context.Name, message);
          logEvent.Exception = exception;
          //
          // Pass the type of your wrapper class here...
          //
          _logger.Log(typeof(MyLogger), logEvent);
        }
        public void Info(string message)
        {
          WriteMessage(LogLevel.Info, message);
        }
      }
