    void PrintAccessRules(string path)
    {	
    	var security = File.GetAccessControl(path);
    	
    	var accessRules = security.GetAccessRules(true, true, typeof(NTAccount));
    	
    	
    	foreach (var rule in accessRules.Cast<FileSystemAccessRule>())
    	{
    		if (!rule.IsInherited)
    		{
    			Console.WriteLine("{0} {1} to {2} was set on {3}.", rule.AccessControlType, rule.FileSystemRights, rule.IdentityReference, path);
    			continue;
    		}
    		
    		FindInheritedFrom(rule, Directory.GetParent(path).FullName);
    	}
    }
    
    void FindInheritedFrom(FileSystemAccessRule rule, string path)
    {
    	var security = File.GetAccessControl(path);
    	var accessRules = security.GetAccessRules(true, true, typeof(NTAccount));
    	
    	var matching = accessRules.OfType<FileSystemAccessRule>()
    		.FirstOrDefault(r => r.AccessControlType == rule.AccessControlType && r.FileSystemRights == rule.FileSystemRights && r.IdentityReference == rule.IdentityReference);
    	
    	if (matching != null)
    	{
    		if (matching.IsInherited) FindInheritedFrom(rule, Directory.GetParent(path).FullName);
    		else Console.WriteLine("{0} {1} to {2} is inherited from {3}", rule.AccessControlType, rule.FileSystemRights, rule.IdentityReference, path);
    	}
    }
