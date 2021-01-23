    private List<DiskInfo> GetDiskInfo()
    {
    	List<DiskInfo> disks = new List<DiskInfo>();
    	SelectQuery query = new SelectQuery("SELECT Size, FreeSpace, Name, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 3");
    
    	ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(scope, query);
    	ManagementObjectCollection collection = moSearcher.Get();
    	foreach (ManagementObject res in collection)
    	{
    		float size = Convert.ToSingle(res["Size"]) / 1024f;
    		float usedSpace = size - (Convert.ToSingle(res["FreeSpace"]) / 1024f);
    		DiskInfo di = new DiskInfo();
    		di.Name = res["Name"].ToString();
    		di.Size = ConvertVal(size);
    		di.UsedSpace = ConvertVal(usedSpace);
    		if (size > 0)
    		{
    			di.PercentUsed = ((usedSpace / size) * 100).ToString("N0");
    		}
    		else
    		{
    			di.PercentUsed = "0";
    		}
    		if (res["FileSystem"] != null)
    		{
    			di.FileSystem = res["FileSystem"].ToString();
    			disks.Add(di);
    		}   				            
    	}
    
    	return disks;
    }
