    public class LoggingMethodHandlerDecorator<T> 
        : IMethodHandler<T>
    {
        private readonly IMethodHandler<T> handler;
        public LoggingMethodHandlerDecorator(
            IMethodHandler<T> handler)
        {
            this.handler = handler;
        }
        public void Handle(T parameters)
        {
            try
            {
                this.handler.Handle(parameters);
            }
            catch (Exception ex)
            {
                //******************************
                //Code for logging will go here.
                //******************************
                ErrorHandlers.ThrowServerErrorException(ex);
                throw;
            }
        }
    }
