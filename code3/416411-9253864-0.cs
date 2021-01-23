    class ResolveMac
    {
        private const short AF_INET6 = 23;
        #region Structs for ResolveIpNetEntry2
        struct MIB_IPNET_ROW2
        {
            public SOCKADDR_INET Address;
            public uint InterfaceIndex;
            public ulong InterfaceLuid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] PhysicalAddress;
            public uint PhysicalAddressLength;
            public NL_NEIGHBOR_STATE State;
            public byte Flags;
            public uint LastReachable;
        }
        private struct SOCKADDR_INET
        {
            public SOCKADDR_IN6 Ipv6;
        }
        private struct SOCKADDR_IN6
        {
            public short sin6_family;
            public ushort sin6_port;
            public uint sin6_flowinfo;
            public in6_addr sin6_addr;
            public uint sin6_scope_id;
        }
        struct in6_addr
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Byte;
        }
        #endregion
        private enum NL_NEIGHBOR_STATE
        {
            NlnsUnreachable,
            NlnsIncomplete,
            NlnsProbe,
            NlnsDelay,
            NlnsStale,
            NlnsReachable,
            NlnsPermanent,
            NlnsMaximum
        }
        [DllImport("Iphlpapi.dll")]
        private static extern int ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row,
            ref SOCKADDR_INET SourceAddress);
        public static byte[] GetMacFromIPv6Address(IPAddress ipv6Address)
        {
            if (ipv6Address.AddressFamily != 
                System.Net.Sockets.AddressFamily.InterNetworkV6)
                throw new ArgumentException(
                    "The IPAddress provided was not an IPv6 address.");
            
            //set up target address
            MIB_IPNET_ROW2 row2 = new MIB_IPNET_ROW2();
            row2.PhysicalAddress = new byte[32];
            row2.State = NL_NEIGHBOR_STATE.NlnsReachable;
            row2.Address.Ipv6.sin6_addr.Byte = new byte[16];
            row2.Address.Ipv6.sin6_family = AF_INET6;
            row2.Address.Ipv6.sin6_flowinfo = 0;
            row2.Address.Ipv6.sin6_port = 0;
            row2.Address.Ipv6.sin6_scope_id = Convert.ToUInt32(ipv6Address.ScopeId);
            
            byte[] ipv6AddressBytes = ipv6Address.GetAddressBytes();
            System.Buffer.BlockCopy(ipv6AddressBytes, 0, 
                row2.Address.Ipv6.sin6_addr.Byte, 0, ipv6AddressBytes.Length);
            //get this machine's local IPv6 address
            SOCKADDR_INET sock = new SOCKADDR_INET();
            sock.Ipv6.sin6_family = AF_INET6;
            sock.Ipv6.sin6_flowinfo = 0;
            sock.Ipv6.sin6_port = 0;
            sock.Ipv6.sin6_addr.Byte = new byte[16];
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == 
                    System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    sock.Ipv6.sin6_addr.Byte = address.GetAddressBytes();
                    break;
                }
            }
            foreach (NetworkInterface netInterface in 
                NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    row2.InterfaceIndex = (uint)clsNetworkStats.GetInterfaceIndex(
                        netInterface.Description);
                    break;
                }
            }
            int result = ResolveIpNetEntry2(ref row2, ref sock);
            if (result != 0)
                throw new ApplicationException(
                    "The call to ResolveIpNetEntry2 failed; error number: " + 
                    result.ToString());
            byte[] macAddress = new byte[6];
            System.Buffer.BlockCopy(row2.PhysicalAddress, 0, macAddress, 0, 6);
            return macAddress;
        }
    }
