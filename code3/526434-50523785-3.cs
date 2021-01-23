    namespace Common.Utils.LogHelper
    {
        public class Log4NetExtentedLoggingPatternLayout : PatternLayout
        {
            public Log4NetExtentedLoggingPatternLayout()
            {
                var customConverter = new log4net.Util.ConverterInfo()
                {
                    Name = "exceptionCode",
                    Type = typeof(Log4NetExtentedLoggingPatternConverter)
                };
    
                AddConverter(customConverter);
            }
        }
    }
