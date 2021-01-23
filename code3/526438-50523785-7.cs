    namespace Common.Utils.LogHelper
    {
        public class Log4NetExtentedLoggingPatternConverter : PatternConverter
        {
            protected override void Convert(TextWriter writer, object state)
            {
                if (state == null)
                {
                    writer.Write(SystemInfo.NullText);
                    return;
                }
    
                var loggingEvent = state as LoggingEvent;
                var messageObj = loggingEvent.MessageObject as Log4NetExtentedLoggingCustomParameters;
    
                if (messageObj == null)
                {
                    writer.Write(SystemInfo.NullText);
                }
                else
                {
                    switch (this.Option.ToLower()) //this.Option = "Code"
                    {
                        case "code": //config conversionPattern parameter -> %exceptionCode{Code}
                            writer.Write(messageObj.ExceptionCode);
                            break;  
                        default:
                            writer.Write(SystemInfo.NullText);
                            break;
                    }
                }
            }
        }
    }
