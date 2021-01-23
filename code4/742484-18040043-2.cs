    MemoryStream stream = new MemoryStream();
    using (BinaryWriter writer = new BinaryWriter(stream))
    {
        writer.Write(myByte);
        writer.Write(myInt32);
        writer.Write("Hello");
    }
    byte[] bytes = stream.ToArray();
