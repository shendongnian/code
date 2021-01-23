    public static class LoggerManager
    {
        public enum eLogType
        {
            Information = 0,
            Warning = 1,
            Error = 2
        }
        public enum eLogContext
        {
            Application = 0,
            Session = 1
        }
        /// <summary>
        ///  Method for logging custom message
        /// </summary>
        /// <param name="logContext"></param>
        /// <param name="logType"></param>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public static void Log(eLogContext logContext, eLogType logType, HttpContext context, string message)
        {
            switch (logContext)
            {
                case eLogContext.Application:
                    //TODO: log application type event...
                    break;
                case eLogContext.Session:
                    //TODO: log session type event...
                    break;
                default:
                    throw new NotImplementedException("eLogContext '" + logContext.ToString() + "' is not implemented!");
            }
        }
    }
