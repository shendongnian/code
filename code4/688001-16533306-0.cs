    public static class Logger
    {
        private static readonly string LOG_FILENAME = "logfile.txt";
        private static readonly string LOG_FOLDER = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App name");
        private static readonly string LOG_FULLPATH = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App name", LOG_FILENAME);
        private static Object theLock=new Object();
    
        public static void LogMessageToFile(string msg)
        {
            msg = string.Format("{0:G}: {1}{2}", DateTime.Now, msg, Environment.NewLine);
            lock (theLock)
            {
                File.AppendAllText(LOG_FULLPATH, msg);
            }
        }
    }
