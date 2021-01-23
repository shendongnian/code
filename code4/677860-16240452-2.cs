    class ExceptionManagerContext : IExceptionManagerContext, IDisposable
    {
        public ExceptionManagerContext(ExceptionManager manager)
        {
            manager.PushContext(this);
        }
    
        public bool EnableLogging { get; set; }
    
        void Dispose()
        {
            manager.PopContext(this);
        }
    }
    
