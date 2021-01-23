    public static SecurityIdentifier GetGroupSid(string groupName, string domainControllerIp)
    {
    	SecurityIdentifier sid = null;
    	using (PrincipalContext dcx = new PrincipalContext(ContextType.Domain, domainControllerIp))
    	{
    		GroupPrincipal group = GroupPrincipal.FindByIdentity(dcx, groupName);
    		if (group != null)
    		{
    			sid = group.Sid;
    			group.Dispose();
    		}
    	}
    	return sid;
    }
    public static void AddDaclsAceForGroup(DirectoryEntry dirEntry, string groupName, string ip)
    {
    	SecurityIdentifier sid = GetGroupSid(groupName,ip);
    	try
    	{
    		ActiveDirectoryAccessRule accessRule =
    			new ActiveDirectoryAccessRule(sid,ActiveDirectoryRights.GenericRead, AccessControlType.Allow);
    		dirEntry.ObjectSecurity.AddAccessRule(accessRule);
    		dirEntry.CommitChanges();
    	}
    	catch(Exception e)
    	{
    	}
    }
