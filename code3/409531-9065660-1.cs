      try
      {
        if (!Directory.Exist(path))
        {
           // Try to create the directory.
           DirectoryInfo di = Directory.CreateDirectory(path);
        }
      catch (IOException ioex)
      {
         Console.WriteLine(ioex.Message)
      }
