    DirectorySecurity ds = Directory.GetAccessControl(folderPath);
    FileSystemRights allExceptRead =
        FileSystemRights.FullControl & ~FileSystemRights.ReadAndExecute;
    // Use AccessControlType.Deny instead of Allow.
    FileSystemAccessRule fsa = new FileSystemAccessRule(username,
                                                        allExceptRead,
                                                        AccessControlType.Deny);
    ds.AddAccessRule(fsa);
    Directory.SetAccessRule(ds);
