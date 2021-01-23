    class LoggerSpy : ILogger
    {
        public string LogWasCalled;
    
        public void Log(string message)
        {
            LogWasCalled = true;;
        }
    }
