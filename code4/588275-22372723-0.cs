    NetworkInterface[] arr = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface item in arr)
    {
        PhysicalAddress mac = item.GetPhysicalAddress();
        string stringFormatMac = string.Join(":", mac.GetAddressBytes().Select(varByte => varByte.ToString("X2")));
    }
