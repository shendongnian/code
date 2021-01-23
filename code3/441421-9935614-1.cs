    public class SvcHelper
    {
        private static ConcurrentDictionary<ChannelFactoryCacheKey, ChannelFactory> ChannelFactories = new ConcurrentDictionary<ChannelFactoryCacheKey, ChannelFactory>();
        public static void Using<TServiceContract>(Action<TServiceContract> action) where TServiceContract : class
        {
            SvcHelper.Using<TServiceContract>(action, "*");
        }
        public static void Using<TServiceContract>(Action<TServiceContract> action, string endpointConfigurationName) where TServiceContract : class
        {
            ChannelFactoryCacheKey cacheKey = new ChannelFactoryCacheKey(typeof(TServiceContract), endpointConfigurationName);
            ChannelFactory<TServiceContract> channelFactory = (ChannelFactory<TServiceContract>)SvcHelper.ChannelFactories.GetOrAdd(
                                                                                                                                    cacheKey,
                                                                                                                                    cacheKey => new ChannelFactory<TServiceContract>(cacheKey.EndpointConfigurationName));
            TServiceContract typedChannel = channelFactory.CreateChannel();
            IClientChannel clientChannel = (IClientChannel)typedChannel;
            try
            {
                using(new OperationContextScope((IContextChannel)typedChannel))
                {
                    action(typedChannel);
                }
            }
            finally
            {
                try
                {
                    clientChannel.Close();
                }
                catch
                {
                    clientChannel.Abort();
                }
            }
            
        }
        private sealed class ChannelFactoryCacheKey : IEquatable<ChannelFactoryCacheKey>
        {
            public ChannelFactoryCacheKey(Type channelType, string endpointConfigurationName)
            {
                this.channelType = channelType;
                this.endpointConfigurationName = endpointConfigurationName;
            }
            private Type channelType;
            public Type ChannelType
            {
                get
                {
                    return this.channelType;
                }
            }
            private string endpointConfigurationName;
            public string EndpointConfigurationName
            {
                get
                {
                    return this.endpointConfigurationName;
                }
            }
            public bool Equals(ChannelFactoryCacheKey compareTo)
            {
                return object.ReferenceEquals(this, compareTo)
                           ||
                       (compareTo != null
                           &&
                       this.channelType == compareTo.channelType
                           &&
                       this.endpointConfigurationName == compareTo.endpointConfigurationName);
            }
            public override bool Equals(object compareTo)
            {
                return this.Equals(compareTo as ChannelFactoryCacheKey);
            }
            public int GetHashCode()
            {
                return this.channelType.GetHashCode() ^ this.endpointConfigurationName.GetHashCode();
            }
        }
    } 
