    public abstract class ViewModel
    {
        private readonly IInfrastructureFactory infrastructureFactory;
    
        public ViewModel(IInfrastructureFactory infrastructureFactory)
        {
            this.infrastructureFactory = infrastructureFactory;
        }
    
        public ILoggingService LoggingService
        {
            get { return this.infrastructureFactory.LoggingService; }
        }
    
        // ... Other Common Services Omitted ...
    }
