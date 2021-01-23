    public class GenericTypeInterceptor<TDependency> : TypeInterceptor
        where TDependency : class
    {
        private readonly IInterceptor _interceptor;
        private readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();
        public GenericTypeInterceptor(IInterceptor interceptor)
        {
            if (interceptor == null)
                throw new ArgumentNullException("interceptor");
            _interceptor = interceptor;
        }
        public object Process(object target, IContext context)
        {
            return _proxyGenerator.CreateInterfaceProxyWithTarget(target as TDependency, _interceptor);
        }
        public bool MatchesType(Type type)
        {
            return typeof(TDependency).IsAssignableFrom(type);
        }
    }
