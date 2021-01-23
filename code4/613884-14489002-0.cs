    public class MyDynamicDecoratedServiceFactory
    {
        readonly IMyServiceFactory _realServiceFactory;
        public MyDynamicDecoratedServiceFactory(IMyServiceFactory realServiceFactory)
        {
            _realServiceFactory = realServiceFactory;
        }
        public IMyService Create()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            MyDynamicProxyInterceptor interceptor = new MyDynamicProxyInterceptor(_realServiceFactory);
            IMyService proxyService = proxyGenerator.CreateInterfaceProxyWithTargetInterface<IMyService>(null,interceptor);
            return proxyService;
        }
    }
