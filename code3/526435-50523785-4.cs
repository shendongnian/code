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
        }
    }
