    namespace Common.Utils.LogHelper
    {
        public class Logger
        {
            static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
            public static string LogError(string message, Exception exception = null)
            {
                var logWithErrCode = GetLogWithErrorCode(message);
                Logger.Error(logWithErrCode, exception);
                return logWithErrCode.ExceptionCode;
            }
    
            private static Log4NetExtentedLoggingCustomParameters GetLogWithErrorCode(string message)
            {
                var logWithErrCode = new Log4NetExtentedLoggingCustomParameters();
                logWithErrCode.ExceptionCode = GenerateErrorCode(); //this method is absent for simplicity. Use your own implementation
                logWithErrCode.Message = message;
                return logWithErrCode;
            }
        }
    }
