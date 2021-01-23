    using (var readStream = file.OpenBinaryStream())
    { 
      using(var reader = new StreamReader(readStream)
      {
        var allText = reader.ReadToEnd();
        var writeStream = new MemoryStream();
        using(var writer = new TextWriter(writeStream))
        {
          writer.Write(allText);
          writer.Write(extraText);
        }
        file.SaveBinary(writeStream.ToArray();
      }
    }
