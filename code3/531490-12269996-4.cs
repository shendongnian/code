    public static class Logger
    {
    
        private static object locker = new object();
    
        public static void Log(string source, string message)
        {
            lock (locker) 
            {
                string logFilePath = @"C:\LogFile\log.txt";
    
                using (FileStream file = new FileStream(logFilePath,FileMode.Append,FileAccess.Write,FileShare.None)) 
                {
                    StreamWriter writer = new StreamWriter(file);
    
                    writer.write(source + ": : " + message);   
                    writer.Flush();
                    file.Close();
                }
            }
        }
    
    }
