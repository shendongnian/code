    public static bool HasWritePermissionOnFile(string path)
    {
    	bool writeAllow = false;
    	bool writeDeny = false;
    
    	FileSecurity accessControlList = File.GetAccessControl(path);
    	if (accessControlList == null)
    	{
    		return false;
    	}
    
    	var accessRules = accessControlList.GetAccessRules(true, true, typeof(SecurityIdentifier));
    	if (accessRules == null)
    	{
    		return false;
    	}
    
    	foreach (FileSystemAccessRule rule in accessRules)
    	{
    		if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write)
    		{
    			continue;
    		}
    
    		if (rule.AccessControlType == AccessControlType.Allow)
    		{
    			writeAllow = true;
    		}
    		else if (rule.AccessControlType == AccessControlType.Deny)
    		{
    			writeDeny = true;
    		}
    	}
    
    	return writeAllow && !writeDeny;
    }
