    public static byte[] Compress(object entity)
    {
      using (var stream = new MemoryStream())
      {
        using (var zipStream = new GZipStream(stream, CompressionLevel.Optimal))
        {
          using (var writer = new BsonWriter(zipStream))
          {
            var serializer = new JsonSerializer();
            serializer.Serialize(writer, entity);
          }
        }
        return stream.ToArray();
      }
    }
