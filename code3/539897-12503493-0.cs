    public string GetHDDSerialNumber(string drive)
    {
    	//check to see if the user provided a drive letter
    	//if not default it to "C"
    	if (drive == "" || drive == null)
    	{
    		drive = "C";
    	}
    	//create our ManagementObject, passing it the drive letter to the
    	//DevideID using WQL
    	ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
    	//bind our management object
    	disk.Get();
    	//return the serial number
    	return disk["VolumeSerialNumber"].ToString();
    }
