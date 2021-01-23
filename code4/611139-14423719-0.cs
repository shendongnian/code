    // Dictionary: 
    //   Key = The directory name.
    //   Value = The most recently modified file for that directory.
    public static Dictionary<string, string> GetNewestFiles(string directory)
    {
      return GetNewestFiles(directory, null);
    }
    static Dictionary<string, string> GetNewestFiles(string directory, 
                                                     Dictionary<string, string> dictionary)
    {
      if(dictionary == null)
        dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
      try
      {
        var files = from file in Directory.GetFiles(directory)
                    select new FileInfo(file);
        var latestFile = files.OrderByDescending(file => { return file.LastWriteTimeUtc; }).FirstOrDefault();
        if (latestFile != null)
          dictionary[latestFile.DirectoryName] = latestFile.FullName;
      }
      catch { }
      foreach (var subDirectory in Directory.GetDirectories(directory))
      {
        try
        {
          GetNewestFiles(subDirectory, dictionary);
        }
        catch { }
      }
      
      return dictionary;
    }
