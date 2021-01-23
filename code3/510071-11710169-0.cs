    var readAllow = false;
    var readDeny = false;
    var accessControlList = Directory.GetAccessControl(path);
    if(accessControlList == null)
        return false;
    var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
    if(accessRules ==null)
       return false;
    foreach (FileSystemAccessRule rule in accessRules)
    {
        if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;
        if (rule.AccessControlType == AccessControlType.Allow)
            readAllow = true;
        else if (rule.AccessControlType == AccessControlType.Deny)
            readDeny = true;
    }
    return readAllow && !readDeny;
