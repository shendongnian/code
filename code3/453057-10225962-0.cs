    public class Logger
    {
        public void Log(string message)
        {
            using (StreamWriter w = File.CreateText(ConfigManager.logFile))
            {
                w.WriteLine("[{0}][{1}] {2} ", String.Format("{0:yyyyMMdd HH:mm:ss}",  DateTime.Now), "Info", logMessage);
                w.Flush();
            }
        }
    }
