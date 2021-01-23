    public static List<FileChunk> GetAllForFile(string fileName)
    {
      var chunks = new List<FileChunk>();
      using (FileStream stream = new FileStream(fileName))
      {
          int i = 0;
          while (stream.Position <= stream.Length)
          {
              var chunk = new FileChunk();
              chunk.Number = (i);
              chunk.Offset = (i * 512);
              Stream.Read(chunk.Bytes, 0, 512);
              chunks.Add(chunk);
              i++;
          }
      }
      return chunks;
    }
