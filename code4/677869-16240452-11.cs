    class ExceptionManagerContext : IExceptionManagerContext, IDisposable
    {
        ExceptionManager manager;
        public ExceptionManagerContext(ExceptionManager manager)
        {
            this.manager = manager;
            manager.PushContext(this);
        }
    
        public bool EnableLogging { get; set; }
    
        public void Dispose()
        {
            manager.PopContext();
        }
    }
    
