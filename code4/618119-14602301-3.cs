    ManagementObjectSearcher mosQuery = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
    ManagementObjectCollection queryCollection1 = mosQuery.Get();
    foreach (ManagementObject manObject in queryCollection1)
    {
        Console.WriteLine("Name : " + manObject["name"].ToString());
        Console.WriteLine("Version : " + manObject["version"].ToString());
        Console.WriteLine("Manufacturer : " + manObject["Manufacturer"].ToString());
        Console.WriteLine("Computer Name : " + manObject["csname"].ToString());
        Console.WriteLine("Windows Directory : " + manObject["WindowsDirectory"].ToString());
    }
