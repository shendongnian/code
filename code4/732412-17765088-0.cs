    IEnumerable<string> GetAllAuthorizedFiles(string root, string searchPattern)
    {
        foreach (var fname in GetAuthorizedFiles(root, searchPattern))
            yield return fname;
        foreach (var dir in GetAuthorizedDirectories(root))
        {
            foreach (var fname in GetAllAuthorizedFiles(dir, searchPattern))
                yield return fname;
        }
    }
    string[] GetAuthorizedDirectories(string root)
    {
        try
        {
            return Directory.GetDirectories(root);
        }
        catch (UnauthorizedAccessException)
        {
            return new string[0];
        }
    }
    string[] GetAuthorizedFiles(string root, string searchPattern)
    {
        try
        {
            return Directory.GetFiles(root, searchPattern);
        }
        catch (UnauthorizedAccessException)
        {
            return new string[0];
        }
    }
