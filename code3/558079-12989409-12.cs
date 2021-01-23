    const string dir = "C:\\";
    var fileInfos = new List<FileInfo>();
    GetFiles(new DirectoryInfo(dir), fileInfos);
    fileInfos.Sort((x, y) => y.Length.CompareTo(x.Length));
    foreach (var f in fileInfos)
    {
        Console.WriteLine(f.FullName);
    }
    private static void GetFiles(DirectoryInfo dirInfo, List<FileInfo> files)
    {
        // get all not-system subdirectories
        var subDirectories = dirInfo.EnumerateDirectories()
            .Where(d => (d.Attributes & FileAttributes.System) == 0);
        foreach (DirectoryInfo subdirInfo in subDirectories)
        {
            GetFiles(subdirInfo, files);
        }
        // ok, now we added files from all subdirectories
        // so add non-system files from this directory
        var filesInCurrentDirectory = dirInfo.EnumerateFiles()
            .Where(f => (f.Attributes & FileAttributes.System) == 0);
        files.AddRange(filesInCurrentDirectory);
    }
