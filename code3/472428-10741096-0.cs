    class Log: IDisposable
    {
        private static StreamWriter swLog;
    
        public Log()
        {
           swLog = new StreamWriter("logMAIN.txt");
        }
        public void Dispose()
        {
            swLog.Dispose();
        }
    
        public static void Push(LogItemType type, string message)
        {
            swLog.WriteLine(type + " " + DateTime.Now.TimeOfDay + " " + message);
        }
    }
