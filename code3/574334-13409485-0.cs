    public static bool IsPrivateAddress(this IPAddress addr)
    {
        if(addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
        {
            return addr.IsIPv6LinkLocal || addr.IsIPv6SiteLocal;
        }
        var bytes = addr.GetAddressBytes();
        return
            ((bytes[0] == 10) ||
            ((bytes[0] == 192) && (bytes[1] == 168)) ||
            ((bytes[0] == 172) && ((bytes[1] & 0xf0)==16)));
    }
