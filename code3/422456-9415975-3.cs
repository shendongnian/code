    using (MemoryStream inputStream = new MemoryStream(input))
    {
      using (GZipStream gzip = new GZipStream(inputStream, CompressionMode.Decompress))
      {
        using (StreamReader reader = new StreamReader(gzip, System.Text.Encoding.UTF8))
        {
          return reader.ReadToEnd();
        }
      }
    }
