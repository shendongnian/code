    public static class IPExtensions
    {
       public static int ToInteger(this IPAddress IP)
       {
          int result = 0;
          byte[] bytes = IP.GetAddressBytes();
          result = (int)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
          return result;
       }
       //returns 0 if equal
       //returns 1 if ip1 > ip2
       //returns -1 if ip1 < ip2
       public static int Compare(this IPAddress IP1, IPAddress IP2)
       {
           int ip1 = IP1.ToInteger();
           int ip2 = IP2.ToInteger();
           return (((ip1 - ip2) >> 0x1F) | (int)((uint)(-(ip1 - ip2)) >> 0x1F));
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip1 = IPAddress.Parse("127.0.0.1");
            IPAddress ip2 = IPAddress.Parse("10.254.254.254");
            if (ip1.Compare(ip2) == 0)
               Console.WriteLine("ip1 == ip2");
            else if (ip1.Compare(ip2) == 1)
               Console.WriteLine("ip1 > ip2");
            else if (ip1.Compare(ip2) == -1)
               Console.WriteLine("ip1 < ip2");
        }
    }
