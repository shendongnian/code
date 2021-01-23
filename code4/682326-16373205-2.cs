    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
    ManagementObjectCollection cpus = searcher.Get()
    foreach (ManagementObject queryObj in cpus)
    {
        Console.WriteLine("AddressWidth : {0}", queryObj["AddressWidth"]); //On a 32-bit operating system, the value is 32 and on a 64-bit operating system it is 64.
        Console.WriteLine("DataWidth: {0}", queryObj["DataWidth"]); //On a 32-bit processor, the value is 32 and on a 64-bit processor it is 64
        Console.WriteLine("Architecture: {0}", queryObj["Architecture"]); //Processor architecture used by the platform
    }
