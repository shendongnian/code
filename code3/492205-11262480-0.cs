    class Logger : IDisposable
    {
        private FileStream file; //Only this instance have a right to own it
        private StreamWriter writer;
        private object mutex; //Mutex for synchronizing
        public Logger(string logPath)
        {
            file = new FileStream(logPath);
            writer = new StreamWriter(file);
            mutex = new object();
        }
        // Log is thread safe, it can be called from many threads
        public void Log(string message)
        {
            lock (mutex)
            {
                 writer.WriteLine(message);
            }
        }
        public void Dispose()
        {
              writer.Dispose(); //Will close underlying stream
        }
    }
