    public static class DomainServiceExtensions
    {
        /// <summary>
        /// This method changes the send timeout for the specified 
        /// <see cref="DomainContext"/> to the specifified <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="domainContext">
        /// The <see cref="DomainContext"/> that is to be modified.
        /// </param>
        /// <param name="newTimeout">The new timeout value.</param>
        public static void ChangeTimeout(this DomainContext domainContext, 
                                              TimeSpan newTimeout)
        {
            // Try to get the channel factory property from the domain client 
            // of the domain context. In case that this property does not exist
            // we throw an invalid operation exception.
            var channelFactoryProperty = domainContext.DomainClient.GetType().GetProperty("ChannelFactory");
            if(channelFactoryProperty == null)
            {
                throw new InvalidOperationException("The 'ChannelFactory' property on the DomainClient does not exist.");
            }
            // Now get the channel factory from the domain client and set the
            // new timeout to the binding of the service endpoint.
            var factory = (ChannelFactory)channelFactoryProperty.GetValue(domainContext.DomainClient, null);
            factory.Endpoint.Binding.SendTimeout = newTimeout;
        }
    }
