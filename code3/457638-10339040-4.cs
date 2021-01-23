    class BackupOptions
    {
      public IEnumerable<string> ExtensionsToAllow { get; set; }
      public IEnumerable<string> ExtensionsToIgnore { get; set; }
      public IEnumerable<string> NamesToIgnore { get; set; }
      public bool CaseInsensitive { get; set; }
      public BackupOptions()
      {
        ExtensionsToAllow = new string[] { };
        ExtensionsToIgnore = new string[] { };
        NamesToIgnore = new string[] { };
      }
    }
    
    static void Backup(string sourcePath, string destinationPath, BackupOptions options = null)
    {
      if (options == null)
        optionns = new BackupOptions();
      string[] files = Directory.GetFiles(sourcePath, ".", SearchOption.AllDirectories);
      StringComparison comp = options.CaseInsensitive ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
    
      foreach (var file in files)
      {
        FileInfo info = new FileInfo(file);
        if (options.ExtensionsToAllow.Count() > 0 &&
          !options.ExtensionsToAllow.Any(allow => info.Extension.Equals(allow, comp)))
          continue;
    
        if (options.ExtensionsToIgnore.Any(ignore => info.Extension.Equals(ignore, comp)))
            continue;
    
        if (options.NamesToIgnore.Any(ignore => info.Name.Equals(ignore, comp)))
          continue;
    
        try
        {
          File.Copy(info.FullName, destinationPath + "\\" + info.Name);
        }
        catch (Exception ex)
        {
          // report/handle error
        }
      }
    }
