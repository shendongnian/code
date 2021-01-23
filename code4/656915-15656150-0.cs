    var permissionSet = new PermissionSet(PermissionState.None);    
    var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filename);
    permissionSet.AddPermission(writePermission);
    
    if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
    {}
