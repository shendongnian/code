    StringBuilder sBuilder = new StringBuilder();
    ManagementObjectCollection objects = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration").Get();
    foreach (ManagementObject mObject in objects)
    {
        string description = (string)mObject["Description"];
        string[] addresses = (string[])mObject["IPAddress"];
        string[] subnets = (string[])mObject["IPSubnet"];
        if (addresses == null && subnets == null)
            continue;
        sBuilder.AppendLine(description);
        sBuilder.AppendLine(string.Empty.PadRight(description.Length,'-'));
        if (addresses != null)
        {
            sBuilder.Append("IPv4 Address: ");
            sBuilder.AppendLine(addresses[0]);
            if (addresses.Length > 1)
            {
                sBuilder.Append("IPv6 Address: ");
                sBuilder.AppendLine(addresses[1]);
            }
        }
        if (subnets != null)
        {
            sBuilder.Append("IPv4 Subnet:  ");
            sBuilder.AppendLine(subnets[0]);
            if (subnets.Length > 1)
            {
                sBuilder.Append("IPv6 Subnet:  ");
                sBuilder.AppendLine(subnets[1]);
            }
        }
        sBuilder.AppendLine();
        sBuilder.AppendLine();
    }
    string output = sBuilder.ToString().Trim();
    MessageBox.Show(output);
