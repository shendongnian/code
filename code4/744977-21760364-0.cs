      DirectoryInfo d = new DirectoryInfo(ConfigurationManager.AppSettings["<path>"]);
      List<string> recentDirectories = d.GetDirectories()
                                            .Select(x => x.EnumerateDirectories()
                                                        .OrderByDescending(f => DateTime.Now.AddDays(-14))
                                                        .FirstOrDefault())
                                            .Where(x => x != null)
                                            .Select(x => x.FullName)
                                            .ToList();
      foreach (string dir in recentDirectories)
      {
          Directory.Delete(dir);
      }
      
