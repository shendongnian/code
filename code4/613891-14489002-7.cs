    public class MyDynamicProxyInterceptor : IInterceptor
    {
        readonly IMyServiceChannelFactory _realServiceFactory;
        public MyDynamicProxyInterceptor(IMyServiceChannelFactory realServiceFactory)
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
