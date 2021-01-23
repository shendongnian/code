    writeLog("Device valid");
    
    try
    {
    	Win32.DEV_BROADCAST_DEVICEINTERFACE deviceInterface;
    	deviceInterface = (Win32.DEV_BROADCAST_DEVICEINTERFACE)
    		Marshal.PtrToStructure(eventData, typeof(Win32.DEV_BROADCAST_DEVICEINTERFACE));
    
    
    	foreach (ManagementObject drive in
    			new ManagementObjectSearcher(
    				"select DeviceID, Model from Win32_DiskDrive where InterfaceType='USB'").Get())
    	{
    		// associate physical disks with partitions
    		ManagementObject partition = new ManagementObjectSearcher(String.Format(
    			"associators of {{Win32_DiskDrive.DeviceID='{0}'}} where AssocClass = Win32_DiskDriveToDiskPartition",
    			drive["DeviceID"])).First();
    
    		if (partition != null)
    		{
    			// associate partitions with logical disks (drive letter volumes)
    			ManagementObject logical = new ManagementObjectSearcher(String.Format(
    				"associators of {{Win32_DiskPartition.DeviceID='{0}'}} where AssocClass = Win32_LogicalDiskToPartition",
    				partition["DeviceID"])).First();
    
    			if (logical != null)
    			{
    				// finally find the logical disk entry to determine the volume name
    				ManagementObject volume = new ManagementObjectSearcher(String.Format(
    					"select FreeSpace, Size, VolumeName from Win32_LogicalDisk where Name='{0}'",
    					logical["Name"])).First();
    
    				string capacity = bytesToUnit((ulong)volume["Size"]);
    				string freeSpace = bytesToUnit((ulong)volume["FreeSpace"]);
    
    				writeLog("Drive Letter    "     + logical["Name"].ToString() + Environment.NewLine +
    						 "Drive Name    "       + volume["VolumeName"].ToString() + Environment.NewLine +
    						 "Drive Capacity    "   + capacity + Environment.NewLine +
    						 "Drive Free Space    " + freeSpace);
    			}
    		}
    	}
    }
    catch (Exception exp)
    {
    	writeLog("Exception: " + exp.ToString());
    }
    
    private string bytesToUnit(ulong bytes)
    {
    	string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
    	int i = 0;
    	double dblSByte = bytes;
    
    	if (bytes > 1024)
    	{
    		for (i = 0; (bytes / 1024) > 0; i++, bytes /= 1024)
    		{
    			dblSByte = bytes / 1024.0;
    		}
    	}
    	return String.Format("{0:0.##}{1}", dblSByte, Suffix[i]);
    }
    
    public void writeLog(string log)
    {
    	eventLog1.WriteEntry(log);
    }
