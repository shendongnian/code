    var rootDirFile = Directory
        .EnumerateFiles(yourPath, "*.*", SearchOption.TopDirectoryOnly)
        .OrderByDescending(f => File.GetLastWriteTime(f))
        .Take(1);
    var allNewestFilesOfEachFolder = Directory
        .EnumerateDirectories(yourParth, "*.*", SearchOption.AllDirectories)
        .Select(d => Directory.EnumerateFiles(d, "*.*")
            .OrderByDescending(f => File.GetLastWriteTime(f))
            .FirstOrDefault());
    // put both together, the root-file first
    allNewestFilesOfEachFolder = rootDirFile.Concat(allNewestFilesOfEachFolder);
