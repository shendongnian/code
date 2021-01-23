    _container.RegisterInterceptor<IPersonManager, LoggingInterceptor>();
-
    public static class ContainerExtensions
    {
        public static void RegisterInterceptor<TDependency, TInterceptor>(this IContainer container)
            where TDependency : class
            where TInterceptor : IInterceptor 
        {
            IInterceptor interceptor = container.GetInstance<TInterceptor>();
            if (interceptor == null)
                throw new NullReferenceException("interceptor");
            TypeInterceptor typeInterceptor 
                = new GenericTypeInterceptor<TDependency>(interceptor);
            container.Configure(c => c.RegisterInterceptor(typeInterceptor));
        }
    }
