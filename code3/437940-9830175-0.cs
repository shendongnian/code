    public static List<string> DirSearch(string sDir, List<string> files)
    {
      string extension = Path.GetExtension(f);
      if (extension != null && (extension.Equals(".xml")))
      {
        files.Add(f);
      }
      foreach (string d in Directory.GetDirectories(sDir))
      {
        DirSearch(d, files);
      }
      return files;
    }
