    interface IExceptionManagerContext
    {
        bool EnableLogging { get; }
    }
    
    class DefaultExceptionManagerContext : IExceptionManagerContext
    {
        public bool EnableLogging { get { return true; } }
    }
