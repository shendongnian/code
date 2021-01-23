        private readonly Dictionary<Type, Object> channelFactoryDictionary = new Dictionary<Type, Object>();
        private ChannelFactory<T> GetChannelFactory<T>() where T : class
        {
            if (channelFactoryDictionary.Keys.Contains(typeof(T)))
                return channelFactoryDictionary[typeof(T)] as ChannelFactory<T>;
         
            var channelFactory = new ChannelFactory<T>("*");
            channelFactory.Credentials.UserName.UserName = userName;
            channelFactory.Credentials.UserName.Password = password;
            channelFactoryDictionary.Add(typeof(T), channelFactory);
            return channelFactory;
        }
