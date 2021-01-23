    public static class MyLogger
    {
        private static TextWriter s_writer;
    
        // Not thread-safe. Call this before other threads are allowed to call Log.
        public void Open(string filename) {
            s_writer = TextWriter.Synchronized( File.AppendText(filename) );
        }
    
        // Also not thread-safe.
        public void Close() {
           s_writer.Dispose();
        }
    
        // Thread-safe.
        public void Log(string logMessage, LogLevel logType) {
            s_writer.WriteLine("\r\n{0} logged at {1} {2} : {3}",
                logType.ToString().ToUpper(), DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString(), logMessage);
        }    
    }
