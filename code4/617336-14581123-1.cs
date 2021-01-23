    public static class Container
    {
        private static IKernel _container;
        static Container()
        {
            _container = ...; //Create the kernel and define container
        }
        public static IKernel Current { get { return _container; } }
    }
    public LogScopeAttribute(string header, string footer)
    {
        _header = header;
        _footer = footer;
        _logScopeInterceptorFactory = Container.Current.Get<ILogScopeInterceptorFactory>();
    }
