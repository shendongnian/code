    static IEnumerable<string> ApplyAllFiles(string folder, string searchPattern, Action<string> fileAction)
    {
        foreach (string file in Directory.GetFiles(folder, searchPattern))
        {
            fileAction(file);
            yield return file;
        }
        ...
    }
    var textfiles = ApplyAllFiles(t, "*.txt", ProcessFile).ToArray();
