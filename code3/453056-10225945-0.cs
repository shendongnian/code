    public class Logger
    {
        private static StreamWriter w;
        public void Log(string message)
        {
            if(w == null) w = File.CreateText(ConfigManager.logFile);
            {
                w.WriteLine("[{0}][{1}] {2} ", String.Format("{0:yyyyMMdd HH:mm:ss}",  DateTime.Now), "Info", logMessage);
                w.Flush();
            }
        }
    }
