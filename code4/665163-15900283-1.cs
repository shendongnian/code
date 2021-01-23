    /// <summary>
    /// Method to create a listner on the subscribed channel.
    /// </summary>
    /// <typeparam name="T">The type of data to be passed.</typeparam>
    /// <param name="address">The base address to use for the WCF connection. 
    /// An example being 'net.pipe://localhost' which will be appended by a service 
    /// end keyword 'net.pipe://localhost/ServiceEnd'.</param>
    public static T AddListnerToServiceHost<T>(string address)
    {
        ChannelFactory<T> pipeFactory = 
            new ChannelFactory<T>(new NetNamedPipeBinding(), 
                                         new EndpointAddress(String.Format("{0}/{1}",
                                                                                      address, 
                                                                                      serviceEnd)));
        T pipeProxy = pipeFactory.CreateChannel();
        return pipeProxy;
    }
