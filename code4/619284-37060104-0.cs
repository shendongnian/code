    var localDrives = Environment.GetLogicalDrives();
    var localUsers = new List<string>();
    var query = new SelectQuery("Win32_UserAccount") { Condition = "SIDType = 1 AND AccountType = 512" };
    var searcher = new ManagementObjectSearcher(query);
    
    foreach (ManagementObject envVar in searcher.Get())
    {
        foreach (string drive in localDrives)
    	{
    		var dir = Path.Combine(String.Format("{0}Users", drive), envVar["name"].ToString());
    		if (Directory.Exists(dir))
            {
    			localUsers.Add(envVar["name"].ToString());
    		}
    	}
    }
