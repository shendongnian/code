    string strHostName = System.Net.Dns.GetHostName();;
    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
    IPAddress[] addr = ipEntry.AddressList;
    Console.WriteLine(addr[addr.Length-1].ToString());
    if (addr[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    Console.WriteLine(addr[0].ToString()); //ipv6
                }
