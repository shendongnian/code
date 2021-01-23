    public IEnumerable<string> EnumerateLeafFolders(string root)
    {
        bool anySubfolders = false;
        foreach (var subfolder in Directory.EnumerateDirectories(root))
        {
            anySubfolders = true;
            foreach (var leafFolder in EnumerateLeafFolders(subfolder))
                yield return leafFolder;
        }
        if (!anySubfolders)
            yield return root;
    }
