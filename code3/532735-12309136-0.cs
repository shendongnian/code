    byte[] serialized;
    using (MemoryStream stream = new MemoryStream(serialized))
    using (TextWriter textWriter = new StreamWriter(stream))
    {
      serializer.Serialize(textWriter, stuffToSerialize);
      serialized = stream.ToArray();
    }
