    public byte[] Serialize<T>(T thisObj)
    {
        var serializer = MessagePackSerializer.Create<T>();
        using (var byteStream = new MemoryStream())
        {
            serializer.Pack(byteStream, thisObj);
            return byteStream.ToArray();
        }
    }
    public T Deserialize<T>(byte[] bytes)
    {
        var serializer = MessagePackSerializer.Create<T>();
        using (var byteStream = new MemoryStream(bytes))
        {
            return serializer.Unpack(byteStream);
        }
    }
