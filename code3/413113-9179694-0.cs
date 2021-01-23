    public static string GetProcessOwner()
    {
    	try
    	{
    		var resultUserName = string.Empty;
    
    		ConnectionOptions opt = new ConnectionOptions();
    
    		string path = string.Format(@"\\{0}\root\cimv2", machineName);
    
    		ManagementScope scope = new ManagementScope(path, opt);
    
    		scope.Connect();
    
    		var query = new ObjectQuery(string.Format("Select * From Win32_Process Where Name = '{0}'", processName));
    		ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    
    		var processList = searcher.Get();
    
    		foreach (ManagementObject obj in processList)
    		{
    			string[] argList = new string[] { string.Empty, string.Empty };
    			int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
    
    			if (returnVal == 0)
    			{
    				// return DOMAIN\user 
    				//return argList[1] + "\\" + argList[0];
    				resultUserName = argList[0];
    			}
    		}
    		
    		return resultUserName; 
    	}
    	catch (Exception exc)
    	{
    		Debug.WriteLine(exc.Message);
    
    		return string.Empty;
    	}
    }
