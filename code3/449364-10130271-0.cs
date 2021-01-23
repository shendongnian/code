    public static class Log
    {
        private static readonly object SyncLock = new object();
        private static ILogFactory _loggerFactory;
        private static void EnsureFactory()
        {
            if (_loggerFactory == null)
            {
                lock (SyncLock)
                {
                    if (_loggerFactory == null)
                    {
                        _loggerFactory = ServiceLocator.Get<ILogFactory>();
                    }
                }
            }
        }
        public static ILogHandler For(object itemThatRequiresLogging)
        {
            if (itemThatRequiresLoggingServices == null)
                throw new ArgumentNullException("itemThatRequiresLogging");
            return For(itemThatRequiresLoggingServices.GetType());
        }
        public static ILogHandler For(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            EnsureFactory();
            return _loggerFactory.CreateFor(type);
        }
        public static ILogHandler For<T>()
        {
            return For(typeof(T));
        }
    }
