    public static class IpExtensions
    {
        public static uint ToUint32(this IPAddress ipAddress)
        {
            var bytes = ipAddress.GetAddressBytes();
            
            return ((uint)(bytes[0] << 24)) |
                   ((uint)(bytes[1] << 16)) |
                   ((uint)(bytes[2] << 8)) |
                   ((uint)(bytes[3]));
        }
    }
    public static int CompareIpAddresses(IPAddress first, IPAddress second)
    {
        var int1 = first.ToUint32();
        var int2 = second.ToUint32();
        if (int1 == int2)
            return 0;
        if (int1 > int2)
            return 1;
        return -1;
    }
    void Main()
    {
        var ip1 = new IPAddress(new byte[] { 255, 255, 255, 255 });
        var ip2 = new IPAddress(new byte[] { 0, 0, 0, 0 });
        Console.WriteLine(CompareIpAddresses(ip1, ip2));
    }
