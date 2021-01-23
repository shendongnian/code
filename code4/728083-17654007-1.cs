    var targetFiles = new List<string>();
    foreach (var f in Directory.GetFiles(targetDir))
    {
        targetFiles.Add(Path.GetFileName(f));
    }
    var missingFiles = new List<string>();
    foreach (var f in Directory.GetFiles(sourceDir))
    {
        if (targetFiles.Contains(Path.GetFileName(f))) { continue; }
        missingFiles.Add(Path.GetFileName(f));
    }
