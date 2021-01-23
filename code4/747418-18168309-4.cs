    static IEnumerable<string> ApplyAllFiles(string folder, Action<string> fileAction)
    {
        IEnumerable<string> files = Directory.GetFiles(folder);
        foreach (string file in files)
        {
            fileAction(file);
        }
        foreach (string subDir in Directory.GetDirectories(folder))
        {
            try
            {
                files = files.Concat(ApplyAllFiles(subDir, fileAction));
            }
            catch
            {
                // swallow, log, whatever
            }
        }
        return files;
    }
    
