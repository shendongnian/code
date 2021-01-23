    public static class NHibernateSessions
    {
        private static readonly Lazy<SessionFactory> lazyFactory;
    
        static NHibernateSessions
        {
            lazyFactory = new Lazy<SessionFactory >(
                () => NHibernateSessions.CreateSessionFactory());
        }
    
        public static SessionFactory Factory
        {
            get
            {
                return NHibernateSessions.lazyFactory.Value;
            }
        }
        public static void Initialize()
        {
            if(!NHibernateSessions.lazyFactory.IsValueCreated)
            {
                // Access the value to force initialization.
                var factory = lazyFactory.Value;
            }
        }
    
        private SessionFactory CreateSessionFactory()
        {
            // Add code here to configure and create factory.
        }
    }
