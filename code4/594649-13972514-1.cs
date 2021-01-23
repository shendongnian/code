    public class GenericTypeInterceptor<TDependency> : TypeInterceptor
        where TDependency : class
    {
        private readonly IInterceptor _interceptor;
        public GenericTypeInterceptor(IInterceptor interceptor)
        {
            if (interceptor == null)
                throw new NullReferenceException("interceptor");
            _interceptor = interceptor;
        }
        public object Process(object target, IContext context)
        {
            var proxyGenerator = new ProxyGenerator();
            return proxyGenerator.CreateInterfaceProxyWithTarget(target as TDependency, _interceptor);
        }
        public bool MatchesType(Type type)
        {
            return typeof(TDependency).IsAssignableFrom(type);
        }
    }
