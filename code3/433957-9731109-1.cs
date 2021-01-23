    class FileLogger : ILogger
    {
        public void Log(string message)
        {
             //Append to file
        }
    }
    class EmptyLogger : ILogger
    {
        public void Log(string message)
        {
             //Do nothing
        }
    }
