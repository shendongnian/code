    static void Main(string[] args)
    {
        string ip1 = "11.2.3.4";
        string ip2 = "1.12.3.4";
        uint ipInt1 = ipAddressToInt(ip1);
        uint ipInt2 = ipAddressToInt(ip2);
        Console.WriteLine(ipInt1 < ipInt2);
        Console.ReadLine();
    }
    private static uint ipAddressToInt(string ip)
    {
        uint retVal;
        System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(ip);
        byte[] IPBytes = ipAddress.GetAddressBytes(); 
        retVal = (uint)IPBytes[3] << 24;
        retVal += (uint)IPBytes[2] << 16;
        retVal += (uint)IPBytes[1] << 8;
        retVal += (uint)IPBytes[0]; 
        return retVal;
    }
