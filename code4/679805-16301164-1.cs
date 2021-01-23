    public class MyAppender : AppenderSkeleton    
    {
        private static bool TurnDebugOn = false;
        public static SetDebugLogging(bool toSet){
            TurnDebugOn = toSet;
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            bool logEvent = true;
            LogLevel logLevel = LogLevel.Err;
            switch (loggingEvent.Level.Name)
            {
                case "DEBUG":
                    logEvent = TurnDebugOn;
                    logLevel = LogLevel.Debug;
                    break;
                case "WARN":
                case "INFO":
                    logLevel = LogLevel.Info;
                    break;
                case "ERROR":
                    logLevel = LogLevel.Err;
                    break;
                case "FATAL":
                    logLevel = LogLevel.Critical;
                    break;
            }
            if(logEvent){
                LogService.Log(LogNameEnum.Exception, LogCategoryEnum.BusinessLogic, logLevel, RenderLoggingEvent(loggingEvent));
            }
        }
    } 
