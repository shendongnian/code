    public class LoggingInterceptor : IInterceptor
    {
        readonly ILoggingFactory loggingFactory;
    
        public LoggingInterceptor(ILoggingFactory loggingFactory)
        {
            this.loggingFactory = loggingFactory;
        }
    
        public void Intercept(IInvocation invocation)
        {
            ILogger logger = loggingFactory.Create(invocation.TargetType);
            //..
        }
    }
