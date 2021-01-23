    private void RecursiveAdd(SvnClient client, string targetPath, List<string> ignoreList)
    {
        foreach (var fileEntry in Directory.EnumerateFileSystemEntries(targetPath))
        {
            if (ignoreList.Any(fileEntry.Contains))
                continue;
    
            Runtime.ActiveLog.Info(fileEntry);
            client.Add(fileEntry, new SvnAddArgs()
                                        {
                                            Depth = SvnDepth.Empty,
                                            Force = true
                                        });
    
            if (Directory.Exists(fileEntry))
                RecursiveAdd(client, fileEntry, ignoreList);
        }
    }
    
    public AddPath(string targetPath)
    {
        using (var client = new SvnClient())
        {
            var ignoreList = GetIgnore(targetPath);
            RecursiveAdd(client, targetPath, ignoreList);
        }
    }
