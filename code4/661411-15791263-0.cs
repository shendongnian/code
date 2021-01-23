    try
    {
    ManagementObjectSearcher searcher =
        new ManagementObjectSearcher("root\\CIMV2",
        "SELECT * FROM Win32_Service");
    
    foreach (ManagementObject queryObj in searcher.Get())
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Win32_Service instance");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("InstallDate: {0}", queryObj["InstallDate"]);
        Console.WriteLine("Name: {0}", queryObj["Name"]);
        Console.WriteLine("ServiceType: {0}", queryObj["ServiceType"]);
        Console.WriteLine("State: {0}", queryObj["State"]);
    }
    }
    catch (ManagementException ex)
    {
    //"An error occurred while querying for WMI data: " + e.Message;
    }
