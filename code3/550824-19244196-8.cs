    public string getMacByIp(string ip)
    {
        var macIpPairs = GetAllMacAddressesAndIppairs();
        int index = macIpPairs.FindIndex(x => x.IpAddress == ip);
        if (index >= 0)
        {
            return macIpPairs[index].MacAddress.ToUpper();
        }
        else
        {
            return null;
        }
    }
    public List<MacIpPair> GetAllMacAddressesAndIppairs()
    {
        List<MacIpPair> mip = new List<MacIpPair>();
        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = "arp";
        pProcess.StartInfo.Arguments = "-a ";
        pProcess.StartInfo.UseShellExecute = false;
        pProcess.StartInfo.RedirectStandardOutput = true;
        pProcess.StartInfo.CreateNoWindow = true;
        pProcess.Start();
        string cmdOutput = pProcess.StandardOutput.ReadToEnd();
        string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";
        foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
        {
            mip.Add(new MacIpPair()
            {
                MacAddress = m.Groups["mac"].Value,
                IpAddress = m.Groups["ip"].Value
            });
        }
        return mip;
    }
    public struct MacIpPair
    {
        public string MacAddress;
        public string IpAddress;
    }
