    static IEnumerable<string> ApplyAllFiles(string folder, string searchPattern, Action<string> fileAction)
    {
        IEnumerable<string> files = Directory.GetFiles(folder, searchPattern);
        foreach (string file in files)
        {
            fileAction(file);
        }
        foreach (string subDir in Directory.GetDirectories(folder))
        {
            try
            {
                files = files.Concat(ApplyAllFiles(subDir, searchPattern, fileAction));
            }
            catch
            {
                // swallow, log, whatever
            }
        }
        return files;
    }
    var textfiles = ApplyAllFiles(t, "*.txt", ProcessFile).ToArray();
