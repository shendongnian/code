    private static IEnumerable<string> Traverse(string rootDirectory)
    {
        IEnumerable<string> files = Enumerable.Empty<string>();
        IEnumerable<string> directories = Enumerable.Empty<string>();
        try
        {
            // The test for UnauthorizedAccessException.
            var permission = new FileIOPermission(FileIOPermissionAccess.PathDiscovery, rootDirectory);
            permission.Demand();
            files = Directory.GetFiles(rootDirectory);
            directories = Directory.GetDirectories(rootDirectory);
        }
        catch
        {
            // Ignore folder (access denied).
            rootDirectory = null;
        }
        if (rootDirectory != null)
            yield return rootDirectory;
        foreach (var file in files)
        {
            yield return file;
        }
        // Recursive call for SelectMany.
        var subdirectoryItems = directories.SelectMany(Traverse);
        foreach (var result in subdirectoryItems)
        {
            yield return result;
        }
    }
