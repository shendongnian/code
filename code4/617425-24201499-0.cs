    public interface IInfrastructureFactory
    {
        ILoggingService LoggingService { get; }
        // ... Other Common Services Omitted ...
    }
    
    public class InfrastructureFactory : IInfrastructureFactory
    {
        private readonly ILoggingService loggingService;
        // ... Other Common Services Omitted ...
    
        public InfrastructureFactory(
            ILoggingService loggingService,
            // ... Other Common Services Omitted ...
            )
        {
            this.loggingService = loggingService;
            // ... Other Common Services Omitted ...
        }
        public ILoggingService LoggingService
        {
            get { return this.loggingService; }
        }
        
        // ... Other Common Services Omitted ...
    }
