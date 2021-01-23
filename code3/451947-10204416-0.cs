    private ILoggerFactory _loggerFactory = LoggerFactory.NullLoggerFactory;
    public ILoggerFactory LoggerFactory
    {
        get { return _loggerFactory; }
        set { _loggerFactory = value; }
    }
