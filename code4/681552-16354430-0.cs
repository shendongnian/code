    public class Log : IDisposable
    {
        public const string logFilePath = Environment.GetEnvironmentVariable("Temp")+"\\testlog.txt";
        public Log() 
        {
                try
                {
                    logFile = new StreamWriter(logFilePath);
                }
                catch
                {
                    logFile = File.AppendText(logFilePath);
                }
        }
    
        public  StreamWriter logFile { get; set; }
    
        public  string LogFilePath
        {
            get
            {
                return logFilePath;
            }
            set
            {
                value = logFilePath;
            }
        }
    
        public  void WriteLog(string logMessage)
        {
            logFile.WriteLine(DateTime.Now);
            logFile.WriteLine(logMessage.ToString());
            logFile.WriteLine();
            logFile.Flush();
        }
        public void Dispose()
        {
            logfile.Dispose();
        }
    }
