    public static byte[] Compress(object entity)
    {
      using (var stream = new MemoryStream())
      {
        using (var zipStream = new GZipStream(stream, CompressionLevel.Optimal))
        {
          Serializer.Serialize(stream, entity);  
        }
        return stream.ToArray();
      }
    }
