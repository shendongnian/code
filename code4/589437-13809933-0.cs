    public string FullPathRelativeTo(string root, string partialPath)
    {
        string oldRoot = Directory.GetCurrentDirectory();
        try {
            Directory.SetCurrentDirectory(root);
            return Path.GetFullPath(partialPath);
        }
        finally {
            Directory.SetCurrentDirectory(oldRoot);
        }
    }
