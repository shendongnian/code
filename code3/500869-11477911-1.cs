    class Logger : IDisposable
    {
        StreamWriter writer;
        public void Logger(string configFileName)
        {
            writer = new StreamWriter(configFileName);
        }
        public void Print(string text) 
        {
            writer.WriteLine(text);
        } 
        public void Dispose()
        {
            writer.Dispose();
        }
    }
