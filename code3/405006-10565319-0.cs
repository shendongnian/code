    foreach (string messageType in allMessages)
    {
        container.Register(
            Component.For<IMessageHangler>()
            .ImplementedBy(GetImplementationFor(messageType))
            .Named(messageType);
        );
    }
    Type GetImplementationFor(string messageType)
    {
        switch (messageType)
        {
            case "com.business.product.RegisterUser": return typeof(RegisterUserService);
            // more ....
            default: throw new Exception("Unhandled message type!");
        }
    }
    // In work:
    void ProcessMessage(IMessage message)
    {
        var handler = this.Container.Resolve<IMessageHandler>(message.MessageType);
        handler.handle(message);
    }
