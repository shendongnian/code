    internal class OopsExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionHandler _innerHandler;
        public OopsExceptionHandler (IExceptionHandler innerHandler)
        {
            if (innerHandler == null)
                throw new ArgumentNullException(nameof(innerHandler));
            _innerHandler = innerHandler;
        }
        public IExceptionHandler InnerHandler
        {
            get { return _innerHandler; }
        }
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            Handle(context);
            return Task.FromResult<object>(null);
        }
        public void Handle(ExceptionHandlerContext context)
        {
            // Create your own custom result here...
            // In dev, you might want to null out the result
            // to display the YSOD.
            // context.Result = null;
            context.Result = new InternalServerErrorResult(context.Request);
        }
    }
