    byte[] serialized;
    using (MemoryStream stream = new MemoryStream(serialized))
    {
      using (TextWriter textWriter = new StreamWriter(stream))
      {
        serializer.Serialize(textWriter, stuffToSerialize);
      }
      // Note: you can even call stream.Close here is you are paranoid enough
      // - ToArray/GetBuffer work on disposed MemoryStream objects.
      serialized = stream.ToArray();
    }
