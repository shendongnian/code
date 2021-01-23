    public IMessageHandler GetHandler<T>()
    {
        Type handlerType = typeof(T);
        return _messageHandlers.FirstOrDefault(x => x.Metadata.MessageType == handlerType);
    }
