    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    
    namespace NormalizeIPRanges
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                if (!BitConverter.IsLittleEndian)
                    // http://stackoverflow.com/a/461766/328397
                    throw new NotSupportedException ("This code requires a little endian CPU");
    
                // IPv4
                string input = "64.233.187.98 - 64.233.188.2";
                var ipRange = input.Replace(" ", "").Split("-".ToCharArray());
    
                if (ipRange.Length == 2)
                {
                    var startBytes =IPAddress.Parse(ipRange[0]).GetAddressBytes();
                    var stopBytes = IPAddress.Parse(ipRange[1]).GetAddressBytes();
    
                    if (startBytes.Length != 4  || stopBytes.Length != 4)
                    {
                        // Note this implementation doesn't imitate all nuances used within MSFT IP Parsing
                        // ref: http://msdn.microsoft.com/en-us/library/system.net.ipaddress.parse.aspx
    
                        throw new ArgumentException("IP Address must be an IPv4 address");
                    }
    
                    // IP addresses were designed to do bit shifting: http://stackoverflow.com/a/464464/328397
                    int startAddress = ipToInt(startBytes[0], startBytes[1], startBytes[2], startBytes[3]);
                    var t  =intToIP(startAddress);
    
                    int stopAddress = ipToInt(stopBytes[0], stopBytes[1], stopBytes[2], stopBytes[3]);
                    var tr = intToIP(stopAddress);
    
    
                    for (int i = startAddress; i <= stopAddress; i++)
                    { 
                        Console.WriteLine(intToIP(i));
                    }
                }
            }
    
            static int ipToInt(int first, int second, int third, int fourth)
            {
                return (first << 24) | (second << 16) | (third << 8) | (fourth);
            }
            static string intToIP(int ip)
            {
                var a = ip >> 24 & 0xFF;
                var b = ip >> 16 & 0xFF;
                var c = ip >> 8 & 0xFF;
                var d = ip & 0xFF;
    
                return String.Format("{0}.{1}.{2}.{3}",a,b,c,d);
            }
    
        }
    }
