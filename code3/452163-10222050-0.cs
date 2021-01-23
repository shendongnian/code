    public HelloMessage Decode(byte[] buffer)
    {
        var message = new HelloMessage();
        Decode<HelloMessage>(reader => 
            { message.Id = reader.ReadByte();
              message.Descriptor = reader.ReadInt32();
            }, buffer);
        return message;
    }
