    public class MyDynamicallyDecoratedServiceClientFactory
    {
        readonly IInterceptor _interceptor;
        public MyServiceClientFactory(IInterceptor interceptor)
        {
            _interceptor = interceptor;
        }
        public IMyService Create()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            IMyService proxy = proxyGenerator.CreateInterfaceProxyWithTargetInterface<IMyService>(null, _interceptor);
            return proxy;
        }
    }
