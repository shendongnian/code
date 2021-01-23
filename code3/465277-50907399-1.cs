    Func<string> SystemId = () =>
    	{
    		ManagementObjectCollection mbsList = null;
    		ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
    		mbsList = mbs.Get();
    		string id = "";
    		foreach (ManagementObject mo in mbsList)
    		{
    			id = mo["ProcessorID"].ToString();
    		}
    		
    		ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
    		ManagementObjectCollection moc = mos.Get();
    		string motherBoard = "";
    		foreach (ManagementObject mo in moc)
    		{
    			motherBoard = (string)mo["SerialNumber"];
    		}
    		
    		string uniqueSystemId = id + motherBoard;
    		return uniqueSystemId;
    	};
    
    	Console.WriteLine(SystemId());
