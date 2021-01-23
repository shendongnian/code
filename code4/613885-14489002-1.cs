    public class MyDynamicProxyInterceptor : IInterceptor
    {
        readonly IInvestorServiceChannelFactory _realServiceFactory;
        public MyDynamicProxyInterceptor(IInvestorServiceChannelFactory realServiceFactory)
        {
            _realServiceFactory = realServiceFactory;
        }
        public void Intercept(IInvocation invocation)
        {
            IMyService realService = _realServiceFactory.CreateRealService();
            IChangeProxyTarget changeProxyTarget = invocation as IChangeProxyTarget;
            changeProxyTarget.ChangeInvocationTarget(realService);
            invocation.Proceed();
        }
    }
