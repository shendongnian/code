    public static List<string> DisplayDnsAddresses()
    {
        var addresses = NetworkInterface.GetAllNetworkInterfaces()
            .Where(a => a.OperationalStatus == OperationalStatus.Up
                        && a.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .Select(a => a.GetIPProperties())
            .SelectMany(ipp => ipp.UnicastAddresses
                .Select(x => x.Address.ToString()));
        return addresses.ToList();
    }
