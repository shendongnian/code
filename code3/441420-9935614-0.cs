    public class SvcHelper
    {
        private static ConcurrentDictionary<Type, ChannelFactory> ChannelFactories = new ConcurrentDictionary<Type, ChannelFactory>();
        public static void Using<TServiceContract>(Action<TServiceContract> action) where TServiceContract : class
        {
            SvcHelper.Using<TServiceContract>(action, "*");
        }
        public static void Using<TServiceContract>(Action<TServiceContract> action, string endpointConfigurationName) where TServiceContract : class
        {
            ChannelFactory<TServiceContract> channelFactory = (ChannelFactory<TServiceContract>)SvcHelper.ChannelFactories.GetOrAdd(
                                                                                                                                    typeof(TServiceContract),
                                                                                                                                    serviceType => new ChannelFactory<TServiceContract>(endpointConfigurationName));
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
    } 
