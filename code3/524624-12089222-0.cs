    using (var memoryStream = new System.IO.MemoryStream())
    {
      using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
      {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(gZipStream, obj);
      }
      return memoryStream.ToArray();
    }
