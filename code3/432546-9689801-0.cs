    public MyClass
    {
        private static readonly ILog _log = log4net.LogManager.GetLogger(typeof(MyClass));
        public void SomeMethod()
        {
            _log.Debug("This is a debug message.);
            _log.Info("This is an informational message.");
            _log.Warn("This is a warning message.");
            _log.Error("This is an error message.");
            _log.Fatal("This is a fatal message.");
        }
    }
