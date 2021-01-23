    private Dictionary<string, IPNetwork> netCache = null;
    public bool IsInRange(string ipAddress)
    {
        if (netCache == null)
            netCache = Ip_Range.ToDictionary((keyItem) => keyItem, (valueItem) => IPNetwork.Parse(valueItem));
        return netCache.Values.Any(net => IPNetwork.Contains(net, IPAddress.Parse(ipAddress)));
    }
