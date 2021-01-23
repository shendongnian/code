    public static Guid Sequence(this Guid source, int index)
    {
        var buffer = source.ToByteArray();
        Buffer.BlockCopy(BitConvertor.GetBytes(index), 0, buffer, 0, sizeof(int));
        return new Guid(buffer);
    }
    
