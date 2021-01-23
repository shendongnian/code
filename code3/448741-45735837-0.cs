    try
    {
        var objectSearcher = new ManagementObjectSearcher("root\\StandardCimv2", $@"select Name, InterfaceName, InterfaceType, NdisPhysicalMedium from MSFT_NetAdapter where ConnectorPresent=1"); //Physical adapter
    
        int count = 0;
        foreach (var managementObject in objectSearcher.Get())
        {
            //The locally unique identifier for the network interface. in InterfaceType_NetluidIndex format. Ex: Ethernet_2.
            string interfaceName = managementObject["InterfaceName"]?.ToString();
            //The interface type as defined by the Internet Assigned Names Authority (IANA).
            //https://www.iana.org/assignments/ianaiftype-mib/ianaiftype-mib
            UInt32 interfaceType = Convert.ToUInt32(managementObject["InterfaceType"]);
            //The types of physical media that the network adapter supports.
            UInt32 ndisPhysicalMedium = Convert.ToUInt32(managementObject["NdisPhysicalMedium"]);
    
            if (!string.IsNullOrEmpty(interfaceName) &&
                interfaceType == 6 &&       //ethernetCsmacd(6) --for all ethernet-like interfaces, regardless of speed, as per RFC3635
                (ndisPhysicalMedium == 0 || ndisPhysicalMedium == 14))   //802.3
            {
                count++;
            }
        }
    
        return count;
    }
    catch (ManagementException)
    {
        //Run-time requirements WMI MSFT_NetAdapter class is included in Windows 8 and Windows Server 2012
    }
