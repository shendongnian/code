    public static string GetMACAddress1()
    {
        ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * FROM Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection objMOC = objMOS.Get();
        string macAddress = String.Empty;
        foreach (ManagementObject objMO in objMOC)
        {
            object tempMacAddrObj = objMO["MacAddress"];
            if (tempMacAddrObj == null) //Skip objects without a MACAddress
            {
                continue;
            }
            if (macAddress == String.Empty) // only return MAC Address from first card that has a MAC Address
            {
                macAddress = tempMacAddrObj.ToString();              
            }
            objMO.Dispose();
        }
        macAddress = macAddress.Replace(":", "");
        return macAddress;
    }
