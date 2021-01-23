       DirectoryInfo[] testDirs = d.GetDirectories();
       List<DirectoryInfo> dirInfos = d.EnumerateDirectories().ToList();
       IOrderedEnumerable<DirectoryInfo> infos = dirInfos.OrderByDescending(f => DateTime.Now.AddDays(-14));
       dirInfos = infos.ToList();
       foreach (DirectoryInfo dir in dirInfos.Count > 0)
       {
           Directory.Delete(dir.FullName);
       }
