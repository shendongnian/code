    public bool HasDirectoryAccess(FileSystemRights fileSystemRights, string directoryPath)
    {
        DirectorySecurity directorySecurity = Directory.GetAccessControl(directoryPath);
        foreach (FileSystemAccessRule rule in directorySecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
        {
            if ((rule.FileSystemRights & fileSystemRights) != 0)
            {
                return true;
            }
        }
        return false;
    }
