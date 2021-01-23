    public string GetMACAddress()
    {
        ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection objMOC = objMOS.Get();
        string MACAddress = String.Empty;
        foreach (ManagementObject objMO in objMOC)
        {
            if (MACAddress == String.Empty) // only return MAC Address from first card   
            {
                MACAddress = objMO["MacAddress"].ToString();
            }
            objMO.Dispose();
        }
        MACAddress = MACAddress.Replace(":", "");
        return MACAddress;
    }
