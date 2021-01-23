	public static class ServiceClientFactory
    {
        private static IServiceConnectionConfiguration _config;
        private static readonly Dictionary<Type, Func<IServiceClient>> Initializers = new Dictionary<Type, Func<IServiceClient>>();
        static ServiceClientFactory()
        {
            Initializers.Add(typeof(Channel), () =>
                                                   {
                                                       return //create the service client based on the endpoint
                                                   });
        }
        public static void Configure(IServiceConnectionConfiguration config)
        {
            _config = config;
        }
        public static T GetService<T>() where T : class, IServiceClient
        {
            return (T)Initializers[typeof (T)]();
        }
    }
