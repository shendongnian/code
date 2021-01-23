    byte[] GetBytesBigEndian(float f)
    {
      var bytes = BitConverter.GetBytes(f);
      if(BitConverter.IsLittleEndian)
        Array.Reverse(bytes);
      return bytes;
    }
    using(var stream = new MemoryStream())
    using(var writer = new BinaryWriter(stream))
    {
       writer.Write(GetBytesBigEndian(x));
       writer.Write(GetBytesBigEndian(y));
       ...
       return stream.ToArray();
    }
