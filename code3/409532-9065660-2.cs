      try
      {
        if (!Directory.Exists(path))
        {
           // Try to create the directory.
           DirectoryInfo di = Directory.CreateDirectory(path);
        }
      }
      catch (IOException ioex)
      {
         Console.WriteLine(ioex.Message);
      }
