    // FileInfo file = ...;
    var acl = file.GetAccessControl();
    
    // Add or Remove access rules on this FileSecurity object
    acl.AddAccessRule(new FileSystemAccessRule(
        @"domain\someuser",
        FileSystemRights.FullControl, /* pick something less */
        AccessControlType.Allow));
    file.SetAccessControl(acl);
