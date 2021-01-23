    private static void SyncDirectories(string oldRoot, string newRoot)
    {
      CreateDirectoriesRecursive(Directory.GetDirectories(oldRoot), newRoot);
    }
    private static void CreateDirectoriesRecursive(string[] oldDirectories, string root)
    {
      foreach (string oldDirectory in oldDirectories)
      {
        string directoryToCreate = root + @"\" + new DirectoryInfo(oldDirectory).Name;
        if (!Directory.Exists(directoryToCreate))
          Directory.CreateDirectory(directoryToCreate);
        if (Directory.GetDirectories(oldDirectory).Count() > 0)
          CreateDirectoriesRecursive(Directory.GetDirectories(oldDirectory), directoryToCreate);
      }
    }
