        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher("root\\CIMV2\\power", 
            "SELECT * FROM Win32_PowerMeter"); 
        foreach (ManagementObject queryObj in searcher.Get())
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Win32_PowerMeter instance");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
        }
