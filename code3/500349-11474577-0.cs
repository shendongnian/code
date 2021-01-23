    public static bool CreateDirectoryWithPermission(string path) {
      bool ok = false;
      DirectoryInfo dir = new DirectoryInfo(path);
    #if !PocketPC
      try {
        DirectorySecurity ds;
        if (dir.Exists) {
          ds = dir.GetAccessControl();
        } else {
          ds = dir.Parent.GetAccessControl();
        }
        string user = Environment.UserDomainName + @"\" + Environment.UserName;
        FileSystemAccessRule rule = new FileSystemAccessRule(user, FileSystemRights.FullControl, AccessControlType.Allow);
        ds.AddAccessRule(rule);
        dir.Create(ds);
        ok = true;
      } catch (Exception) { }
    #endif
      if (!ok) {
        try {
          dir.Create();
          ok = true;
        } catch (Exception) { }
      }
      return ok;
    }
