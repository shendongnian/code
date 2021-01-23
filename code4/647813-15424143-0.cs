    public T Create<T>()
    {
        var factory = new ChannelFactory<T>();
        factory.Endpoint.Behaviors.Add(<here goes your behavior>);
        return factory.CreateChannel();
    }
