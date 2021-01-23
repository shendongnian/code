    var sourceFiles = new List<string>();
    foreach (var f in Directory.GetFiles(sourceDir))
    {
        sourceFiles.Add(Path.GetFileName(f));
    }
    var missingFiles = new List<string>();
    foreach (var f in Directory.GetFiles(targetDir))
    {
        if (sourceFiles.Contains(Path.GetFileName(f))) { continue; }
        missingFiles.Add(Path.GetFileName(f));
    }
