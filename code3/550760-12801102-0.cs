    // client send
    public void Send(object data)
    {
        byte[] sendData = SerializationHelper.Serialize(data);
        base.Send(sendData).RunSynchronously();
    }
    // base send
    protected async void Send(byte[] data)
    {
        await stream.WriteAsync(data, 0, data.Length);
    }
