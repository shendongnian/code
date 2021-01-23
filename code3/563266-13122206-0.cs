    class FooWriter : IDisposable
    {
       private StreamWriter Writer;
       public FooWriter()
       {
          Writer = new StreamWriter("MyFile.txt", false);
       }
       public void Write(string line)
       {
         Writer.WriteLine(line);
       }
       public void Dispose()
       {
            Writer.Dispose();
       }
    }
    
    
    // use it
    
    using (var writer = new FooWriter())
    {
      foreach (var s in args)
                    writer.Write(s);
    }
