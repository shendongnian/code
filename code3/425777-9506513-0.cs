    public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
    {
        ArraySegment<byte> result = this.wrappedEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
        // message contents on the array segment.
        return result;
    }
    
    public override void WriteMessage(Message message, Stream stream)
    {
        MemoryStream ms = new MemoryStream();
        this.wrappedEncoder.WriteMessage(message, ms);
        // message contents in the memory stream
        ms.Position = 0;
        ms.CopyTo(stream);
    }
