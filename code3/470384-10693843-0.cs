    private IEnumerable<DirectoryInfo> EnumerateDirectories(DirectoryInfo dir, string target)
    {
        foreach (var di in dir.EnumerateDirectories("*",SearchOption.TopDirectoryOnly))
        {
            if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                if (di.Name.EndsWith(target, StringComparison.OrdinalIgnoreCase))
                {
                     yield return di;
                     continue;
                }
                foreach (var subDir in EnumerateDirectories(di, target))
                {
                    yield return subDir;
                }
            }
        }
    }
