    public static bool CanRead(string path)
    {
        try
        {
            var readAllow = false;
            var readDeny = false;
            var accessControlList = Directory.GetAccessControl(path);
            if(accessControlList == null)
                return false;
            //get the access rules that pertain to a valid SID/NTAccount.
            var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            if(accessRules ==null)
               return false;
    
            //we want to go over these rules to ensure a valid SID has access
            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;
    
                if (rule.AccessControlType == AccessControlType.Allow)
                    readAllow = true;
                else if (rule.AccessControlType == AccessControlType.Deny)
                    readDeny = true;
            }
    
            return readAllow && !readDeny;
        }
        catch(UnauthorizedAccessException ex)
        {
            return false;
        }
    }
