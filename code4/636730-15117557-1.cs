    private void UdpListener()
    {
        // .... etc ....
        object obj = _service.Deserialize<object>(inputStream);
        if (!(obj is AbstractMessage))
           // complain to yourself via exception, log or other things
        
        var message = obj as AbstractMessage;
        object payload = message.Payload;
        // here you can access on of two things:
        Type payloadType = payload.GetType();
        Type aproximatelySameType = message.GetType().GetGenericArguments()[0];
        // and you can honor this payload like an object or by casting it to whatever
        // you desire, or by reflection, or whatever
        Received(message.Payload);
        listener.Close();
    }
