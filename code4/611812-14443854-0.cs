    ManagementPath path = new ManagementPath() {
        NamespacePath = @"root\cimv2",
        Server = "<REMOTE HOST OR IP>"
    };
    ManagementScope scope = new ManagementScope(path);
    string condition = "DriveLetter = 'C:'";
    string[] selectedProperties = new string[] { "FreeSpace" };
    SelectQuery query = new SelectQuery("Win32_Volume", condition, selectedProperties);
        
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
    using (ManagementObjectCollection results = searcher.Get())
    {
        ManagementObject volume = results.Cast<ManagementObject>().SingleOrDefault();
            
        if (volume != null)
        {
            ulong freeSpace = (ulong) volume.GetPropertyValue("FreeSpace");
            // Use freeSpace here...
        }
    }
