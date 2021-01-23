       using System.ServiceModel.DomainServices.Client;
       /// <summary>
       /// Utility class for changing a domain context's WCF endpoint's
       /// SendTimeout. 
       /// </summary>
       public static class WcfTimeoutUtility
       {
        /// <summary>
        /// Changes the WCF endpoint SendTimeout for the specified domain
        /// context. 
        /// </summary>
        /// <param name="context">The domain context to modify.</param>
        /// <param name="sendTimeout">The new timeout value.</param>
        public static void ChangeWcfSendTimeout(DomainContext context, 
                                                TimeSpan sendTimeout)
        {
          PropertyInfo channelFactoryProperty =
            context.DomainClient.GetType().GetProperty("ChannelFactory");
          if (channelFactoryProperty == null)
          {
            throw new InvalidOperationException(
              "There is no 'ChannelFactory' property on the DomainClient.");
          }
    
          ChannelFactory factory = (ChannelFactory)
            channelFactoryProperty.GetValue(context.DomainClient, null);
          factory.Endpoint.Binding.SendTimeout = sendTimeout;
        }
       }
