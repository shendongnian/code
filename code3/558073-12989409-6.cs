    const string dir = "C:\\";
    var files = Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories);
    var fileInfos = new List<FileInfo>();
    foreach (file in files)
    {
        try { fileInfos.Add(new FileInfo(file)); }
        catch (UnauthorizedAccessException ex) { }
    }
    fileInfos.Sort((x, y) => y.Length.CompareTo(x.Length));
    foreach (var f in fileInfos)
    {
        Console.WriteLine(f.FullName);
    }
