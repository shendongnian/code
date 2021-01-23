    using (var writer = new StreamWriter(new MemoryStream()))
    {
      writer.WriteLine("foo");
      writer.Flush();
      using (var file = File.Open("foo.txt"))
      {
        writer.BaseStream.Position = 0;
        writer.BaseStream.CopyTo(file);
      }
    }    
