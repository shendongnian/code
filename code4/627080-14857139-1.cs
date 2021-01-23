    using System.Management;
    try
    {
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\CIMV2",
                                         "SELECT * FROM Win32_PnPEntity");
        foreach (ManagementObject queryObj in searcher.Get())
        {
            if (queryObj["Caption"].ToString().ToUpper().Contains("ARDUINO"))
            {
                Console.WriteLine(queryObj["Caption"]);
                foreach (PropertyData pd in queryObj.Properties) { Console.WriteLine(pd.Name + " : " + pd.Value); }
            }
        }
    }
    catch (ManagementException e)
    {
        Console.WriteLine(e.Message);
    }
    Console.ReadKey();
