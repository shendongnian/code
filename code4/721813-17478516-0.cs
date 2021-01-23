    public static TResult ExecuteAndReturn<TProxy, TResult>(
        Func<TProxy, TResult> delegateToExecute)
    {
        string endpointUri = ServiceEndpoints.GetServiceEndpoint(typeof(TProxy));
        TResult valueToReturn;
        using (ChannelFactory<T> factory = new ChannelFactory<TProxy>(new BasicHttpBinding(), new EndpointAddress(endpointUri)))
        {
            TProxy proxy = factory.CreateChannel();
            valueToReturn = delegateToExecute(proxy);
        }
        return valueToReturn;
    }
