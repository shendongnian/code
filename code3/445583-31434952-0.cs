    var wmiObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
    
    var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new {
    	FreePhysicalMemory = Double.Parse(mo["FreePhysicalMemory"].ToString()),
    	TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
    }).FirstOrDefault();
    
    if (memoryValues != null) {
    	var percent = ((memoryValues.TotalVisibleMemorySize - memoryValues.FreePhysicalMemory) / memoryValues.TotalVisibleMemorySize) * 100;
    }
