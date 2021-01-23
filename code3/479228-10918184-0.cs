    class MyLogger {
        private FileStream appLogStream;
    
        public MyLogger() {
            appLogStream = new FileStream(logFile, FileMode.Append, FileAccess.Write, FileShare.Read);
            TextWriter logtxtWriter = Console.Out;
            logstrmWriter = new StreamWriter(appLogStream);
            if(!console) Console.SetOut(logstrmWriter);
            logstrmWriter.AutoFlush = true;
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
