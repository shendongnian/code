    using System.Net;
    using System.Runtime.InteropServices;
    [DllImport("iphlpapi.dll", ExactSpelling = true)]
    public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);
    try
    {
        IPAddress hostIPAddress = IPAddress.Parse("XXX.XXX.XXX.XX");
        byte[] ab = new byte[6];
        int len = ab.Length, 
            r = SendARP((int)hostIPAddress.Address, 0, ab, ref len);
        Console.WriteLine(BitConverter.ToString(ab, 0, 6));
    }
    catch (Exception ex) { }
