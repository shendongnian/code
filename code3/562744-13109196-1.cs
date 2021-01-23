    public void GetFolderList()
    {
        var list = new List<string>();
        var root = new DirectoryInfo("c:\\");
        GetFoldersRecursive(root, list);
    }
    
    private static void GetFoldersRecursive(DirectoryInfo root, List<string> list)
    {
        DirectoryInfo[] children;
        try
        {
            list.Add(root.FullName);
            children = root.GetDirectories();
        }
        catch(UnauthorizedAccessException t)
        {
            // access denied
            return;
        }
    
        foreach (var d in children)
            GetFoldersRecursive(d, list);
    }
