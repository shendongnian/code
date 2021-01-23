    public static bool IsConnected()
    {            
        // Use WMI to find devices with the proper hardware id for the Kinect2
        // note that one Kinect2 is listed as three harwdare devices    
        string query = String.Format(WmiQuery, HardwareId);
        using (var searcher = new ManagementObjectSearcher(query))
        {
            using (var collection = searcher.Get())
            {
                return collection.Count > 0;
            }
        }            
    }
    private const string HardwareId = @"VID_045E&PID_02C4";
    private const string WmiQuery = @"SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%{0}%'";
