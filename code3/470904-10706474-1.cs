    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace LoggerSpace
    {
        public static class Logger
        {
            private static StreamWriter swLog;
            private const string sLOG_FILE_PATH = "log.txt";    
            static Logger()
            {
                Logger.OpenLogger();
            }
    
            public static void OpenLogger()
            {
                Logger.swLog = new StreamWriter(sLOG_FILE_PATH, false);
                Logger.swLog.AutoFlush = true;
            }
    
            public static void LogThisLine(string sLogLine)
            {
                Logger.swLog.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\t:" + "\t" + sLogLine);
                Logger.swLog.Flush();
            }
    
            public static void CloseLogger()
            {
                Logger.swLog.Flush();
                Logger.swLog.Close();
            }
        }
    }
