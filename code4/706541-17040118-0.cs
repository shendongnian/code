        public static async void Log(LogMessage logMessage, [CallerMemberName]string method = "", [CallerFilePath]string path = "")
        {
            logMessage.SetCaller(method, path);
            await AddLogToCollection(logMessage);
        }
