        internal class MyInboundInterceptor : IInboundMessageInterceptor
    {
        public MyInboundInterceptor(ServiceBus bus)
        {
            
        }
        public void PreDispatch(IConsumeContext context)
        {
            IConsumeContext<AwesomeCommand> typedContext;
            if (context.TryGetContext(out typedContext))
            {
                // Do SOmething with typedContext.Message
            }
        }
        public void PostDispatch(IConsumeContext context)
        {
        }
    }
