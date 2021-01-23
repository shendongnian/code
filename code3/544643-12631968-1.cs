    using System.Management;
    ManagementObjectSearcher searcher =
        new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");
    ManagementObjectCollection information = searcher.Get();
    foreach (ManagementObject obj in information)
    {
        foreach (PropertyData data in obj.Properties)
            Console.WriteLine("{0} = {1}", data.Name, data.Value);
        Console.WriteLine();
    }
    searcher.Dispose();
