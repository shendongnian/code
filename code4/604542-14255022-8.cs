    private void ProcessFiles(string path, ICollection<string> files)
    {
        foreach (var file in Directory.GetFiles(path).Where(name => name.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)))
        {
            files.Add(file);
        }
        foreach (var directory in Directory.GetDirectories(path))
        {
            ProcessFiles(directory, files);
        }
    }
