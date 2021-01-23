    public class MyServiceClientInterceptor : IInterceptor
    {
        readonly IMyServiceFactory _svcFactory;
        public MyServiceClientInterceptor(IMyServiceFactory svcFactory)
        {
            _svcFactory = svcFactory;
        }
        public void Intercept(IInvocation invocation)
        {
            IMyService realService = _svcFactory.Create();
            IChangeProxyTarget changeProxyTarget = invocation as IChangeProxyTarget;
            changeProxyTarget.ChangeInvocationTarget(realService);
            invocation.Proceed();
        }
    }
