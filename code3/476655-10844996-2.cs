    public static class ServiceClientFactory
    {
        private static IServiceConnectionConfiguration _config;
        private static readonly Dictionary<Type, Action<IServiceClient>> Initializers = new Dictionary<Type, Action<IServiceClient>>();
        static ServiceClientFactory()
        {
            Initializers.Add(typeof(Channel), t =>
                                                  {
                                                      t.Url = _config.ChannelEndpointUrl;
                                                      //configure t using the appropriate endpoint
                                                  });
        }
        public static void Configure(IServiceConnectionConfiguration config)
        {
            _config = config;
        }
        public static T GetService<T>() where T : class, IServiceClient, new()
        {
            var service = new T();
            Initializers[typeof(T)](service);
            return service;
        }
    }
