    static void Main(string[] args)
    {
      var list = new List<string>();
      DirSearch(list, ".");
    
      foreach (var file in list)
      {
        Console.WriteLine(file);
      }
    }
    
    public static void DirSearch(List<string> files, string startDirectory)
    {
      try
      {
        foreach (string file in Directory.GetFiles(startDirectory, "*.*"))
        {
          string extension = Path.GetExtension(file);
    
          if (extension != null)
          {
            files.Add(file);
          }
        }
    
        foreach (string directory in Directory.GetDirectories(startDirectory))
        {
          DirSearch(files, directory);
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
