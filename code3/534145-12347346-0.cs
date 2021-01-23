    DirectoryInfo dirInfo = new DirectoryInfo("yourFolderPath");
    IEnumerable<DirectoryInfo> subDirs = dirInfo.EnumerateDirectories();
    List<string> subDirsNames = new List<string>();
    foreach (var subDir in subDirs)
     {
       subDirsNames.Add(subDir.Name.Trim());
       IEnumerable<string> files = subDir.EnumerateFiles().Select(i => i.Name);
       //do something with this list....
     }
