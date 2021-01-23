    public static bool IpIsInRange(IEnumerable<string> subnets, string ip)
    {
        foreach (var subnet in subnets)
        {
            var splitSubnet = subnet.Split('/');
            var network = new IPNetwork(IPAddress.Parse(splitSubnet[0]), Convert.ToInt32(splitSubnet[1]));
            if (network.Contains(IPAddress.Parse(ip)))
                return true;
        }
        return false;
    }
