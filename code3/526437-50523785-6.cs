    namespace Common.Utils.LogHelper
    {
        public class Log4NetExtentedLoggingCustomParameters
        {
            public string ExceptionCode { get; set; }
    
            public string Message { get; set; }
    
            public override string ToString()
            {
                return Message;
            }
        }
    }
