    public static IEnumerable<string> EnumCorrectWmiNameSpace()
    {
    	const string WMI_NAMESPACE_TO_USE = @"root\Microsoft\sqlserver";
    	try
    	{
    		ManagementClass nsClass =
    			new ManagementClass(
    				new ManagementScope(WMI_NAMESPACE_TO_USE),
    				new ManagementPath("__namespace"),
    				null);
    
    		return nsClass
    			.GetInstances()
    			.Cast<ManagementObject>()
    			.Where(m => m["Name"].ToString().StartsWith("ComputerManagement"))
    			.Select(ns => WMI_NAMESPACE_TO_USE + "\\" + ns["Name"].ToString());
    	}
    	catch (ManagementException e)
    	{
    		Console.WriteLine("Exception = " + e.Message);
    	}
    
    	return null;
    }
