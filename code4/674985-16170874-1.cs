    using (var reader = new StreamReader(file))
    {
      reader.BaseStream.Seek(0, SeekOrigin.Begin);
      body += reader.ReadToEnd();
    }
    rtBox.Rtf = body;
    string[] lines = rtBox.Lines;
