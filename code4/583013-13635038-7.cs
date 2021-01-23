    [DllImport("iphlpapi.dll", CharSet = CharSet.Auto)]
    private static extern int GetBestInterface(UInt32 destAddr, out UInt32 bestIfIndex);
    public static IPAddress GetGatewayForDestination(IPAddress destinationAddress)
    {
        UInt32 destaddr = BitConverter.ToUInt32(destinationAddress.GetAddressBytes(), 0);
        uint interfaceIndex;
        int result = GetBestInterface(destaddr, out interfaceIndex);
        if (result != 0)
            throw new Win32Exception(result);
        foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            var niprops = ni.GetIPProperties();
            if (niprops == null)
                continue;
            var gateway = niprops.GatewayAddresses?.FirstOrDefault()?.Address;
            if (gateway == null)
                continue;
            if (ni.Supports(NetworkInterfaceComponent.IPv4))
            {
                var v4props = niprops.GetIPv4Properties();
                if (v4props == null)
                    continue;
                if (v4props.Index == interfaceIndex)
                    return gateway;
            }
            if (ni.Supports(NetworkInterfaceComponent.IPv6))
            {
                var v6props = niprops.GetIPv6Properties();
                if (v6props == null)
                    continue;
                if (v6props.Index == interfaceIndex)
                    return gateway;
            }
        }
        return null;
    }
