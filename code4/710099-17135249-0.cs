    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    internal class Program
    {
        private static void Main(string[] args)
        {
            NetworkInterface netif =
                NetworkInterface
               .GetAllNetworkInterfaces()
               .Single(networkInterface => networkInterface.Name.ToLower() =="loopback pseudo-interface 1");
            IPInterfaceProperties properties = netif.GetIPProperties();
            UnicastIPAddressInformationCollection unicastIpAddress = properties.UnicastAddresses;
            Console.Write(netif.Name + ": ");
            Console.WriteLine(unicastIpAddress[1].Address);
            Console.ReadLine();
            }
        }
    }
