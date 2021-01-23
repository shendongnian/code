    public ViewModel(ILoggingService logger)
    {
        loggingService= logger;
    }
    public ILoggingService LoggingService
    {
        get
        {
            return this.loggingService;
        }
    }
