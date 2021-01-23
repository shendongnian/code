    public void Send(BrokeredMessage message)
    {
        this.ThrowIfSenderNull("Send");
        this.InternalSender.Send(message);
    }
