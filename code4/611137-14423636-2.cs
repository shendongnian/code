    var rootDirFile = Directory.EnumerateFiles(youParth, "*.*", SearchOption.TopDirectoryOnly)
        .OrderByDescending(f => File.GetLastWriteTime(f)).Take(1);
    var allNewestFilesOfEachFolder = Directory
        .EnumerateDirectories(youParth, "*.*", SearchOption.AllDirectories)
        .Select(d => Directory.EnumerateFiles(d, "*.*")
            .OrderByDescending(f => File.GetLastWriteTime(f))
            .FirstOrDefault());
    allNewestFilesOfEachFolder = rootDirFile.Concat(allNewestFilesOfEachFolder);
