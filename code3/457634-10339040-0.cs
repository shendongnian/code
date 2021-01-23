    class BackupOptions
    {
      public IEnumerable<string> ExtensionsToIgnore { get; set; }
      public IEnumerable<string> NamesToIgnore { get; set; }
      public bool CaseInsensitive { get; set; }
    }
    
    static void Backup(string sourcePath, string destinationPath, BackupOptions options)
    {
      string[] files = Directory.GetFiles(sourcePath, ".", SearchOption.AllDirectories);
      StringComparison comp = options.CaseInsensitive ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
    
      foreach (var file in files)
      {
        FileInfo info = new FileInfo(file);
    
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
