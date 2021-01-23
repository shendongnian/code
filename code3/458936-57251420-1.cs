    using System.Management;
    using System.IO;
    
    public string GetMACAddress()
    {
        string mac_src = "";
        string macAddress = "";
    
        foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
            {
                mac_src += nic.GetPhysicalAddress().ToString();
                break;
            }
        }
        while (mac_src.Length < 12)
        {
            mac_src = mac_src.Insert(0, "0");
        }
        for (int i = 0; i < 11; i++)
        {
            if (0 == (i % 2))
            {
                if (i == 10)
                {
                    macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2));
                }
                else
                {
                    macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2)) + "-";
                }
            }
        }
        return macAddress;
    } 
 
