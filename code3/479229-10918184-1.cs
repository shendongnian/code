    class MyLogger {
        private FileStream appLogStream;
    
        public MyLogger() {
            appLogStream = new FileStream(logFile, FileMode.Append, FileAccess.Write,
                                          FileShare.Read);
            appLogStream.WriteLine("Started at " + DateTime.Now);
        }
    
        public Write(string msg) {
            Console.Write(msg);
            appLogStream.Write(msg);
        }
        public WriteLine(string msg) {
            Console.WriteLine(msg);
            appLogStream.WriteLine(msg);
        }
    }
