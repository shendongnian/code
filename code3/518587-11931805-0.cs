    public List<NetworkAdapter> GetAdapterList()
    {
        ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration ");
        ManagementObjectCollection moc = mgmt.GetInstances();
        List<NetworkAdapter> adapters = new List<NetworkAdapter>();
 
        // Search for adapters with IP addresses
        foreach(ManagementObject mob in moc)
        {
            string[] addresses = (string[])mob.Properties["IPAddress"].Value;
            if (null == addresses)
            {
                continue;
            }
 
            NetworkAdapter na = new NetworkAdapter();
            na.Description = (string) mob.Properties["Description"].Value;
            na.MacAddress = (string) mob.Properties["MACAddress"].Value;
            na.IPAddresses = addresses;
            adapters.Add(na);
        }
        return adapters;
    }
