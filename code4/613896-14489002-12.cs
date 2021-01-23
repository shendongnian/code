    public class MyDynamicallyDecoratedServiceClientFactory
    {
        readonly ProxyGenerator _proxyGenerator;
        readonly IInterceptor _interceptor;
        public MyServiceClientFactory(IInterceptor interceptor)
        {
            _interceptor = interceptor;
            _proxyGenerator = new ProxyGenerator();
        }
        public IMyService Create()
        {
            IMyService proxy = _proxyGenerator.CreateInterfaceProxyWithTargetInterface<IMyService>(null, _interceptor);
            return proxy;
        }
    }
