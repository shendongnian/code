    var allFiles = Directory.EnumerateFiles(sourceDir, "*.dwg")
        .Select(path => new
        {
            Path = path,
            FileName = Path.GetFileName(path),
            VersionStartIndex = Path.GetFileName(path).LastIndexOf('_')
        })
        .Select(x => new
        {
            x.Path,
            x.FileName,
            IsVersionFile = x.VersionStartIndex != -1,
            Version = x.VersionStartIndex == -1 ? new Nullable<int>()
                : x.FileName.Substring(x.VersionStartIndex).TryGetInt(),
            NameWithoutVersion = x.VersionStartIndex == -1 ? x.FileName
                : x.FileName.Substring(0, x.VersionStartIndex)
        })
        .OrderByDescending(x => x.Version)
        .GroupBy(x => x.NameWithoutVersion)
        .Select(g => g.First());
    foreach (var file in allFiles)
    {
        string oldPath = Path.Combine(sourceDir, file.FileName);
        string newPath;
        if (file.IsVersionFile && file.Version.HasValue)
            newPath = Path.Combine(versionPath, file.FileName);
        else
            newPath = Path.Combine(noVersionPath, file.FileName);
        File.Copy(oldPath, newPath, true);
    }
