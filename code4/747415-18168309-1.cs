    static IEnumerable<string> ApplyAllFiles(string folder, Action<string> fileAction)
    {
        foreach (string file in Directory.GetFiles(folder))
        {
            fileAction(file);
            yield return file;
        }
        foreach (string subDir in Directory.GetDirectories(folder))
        {
            try
            {
                foreach (string file in ApplyAllFiles(subDir, fileAction))
                {
                    yield return file;
                }
            }
            catch
            {
                // swallow, log, whatever
            }
        }
    }
