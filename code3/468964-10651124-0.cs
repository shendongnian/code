    var permissionSet = new PermissionSet(PermissionState.None);    
    var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, pathToFolder);
    permissionSet.AddPermission(writePermission);
    if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
    {
        // do your stuff
    }
    else
    {
        // alternative stuff
    }
