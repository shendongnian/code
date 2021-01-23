    public static class LogWrapper
    {
        private static Logger _logger // where Logger assumes that is the actual NLog logger, not sure if it is the right name but this is for example
    
        public static void Info(string logString, object[] params)
        {
            // Just prepend the method name and then pass the string and the params to the NLog object
            _logger.Info(
                string.Concat(
                    GetMethodName(),
                    ": ",
                    logString
                ),
                params
            );
        }
    
        public static void Warn(string logString, object[] params)
        {
            // _logger.Warn(
            //  You get the point ;)
            // )
        }
    
        private static string GetMethodName()
        {
            var stackTrace = new StackTrace(); // Make sure to add using System.Diagnostics at the top of the file
            var callingMethodName = stackTrace.GetFrame(2).GetMethod().Name; // Possibly a different frame may have the correct method, might not be 2, might be 1, etc.
        }
    }
