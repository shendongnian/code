    // Somewhere else
    BlockingCollection<SomethingLikeAMessage> RecievedMessageBuffer = new BlockingCollection<SomethingLikeAMessage>();
    
    // Something like this where your example was
    while (this.IsListening)
    {
        SomethingLikeAMessage message;
        if (RecievedMessageBuffer.TryTake(out message, 5000);
        {
            message.Reconstruct();
            message.HandleMessage(messageHandler);
        }
    }
