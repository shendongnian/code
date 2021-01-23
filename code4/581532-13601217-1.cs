    using(var stream = new MemoryStream())
    using(var writer = new BinaryWriter(stream))
    {
       writer.Write(x);
       writer.Write(y);
       ...
       return stream.ToArray();
    }
