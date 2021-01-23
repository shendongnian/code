    namespace SocketTest
    {
        using System;
        using System.Net;
        using System.Net.Sockets;
        using System.Runtime.InteropServices;
        using System.Runtime.Serialization;
    
        
    
        [Serializable]
        public class SocketUtilException : Exception
        {
            
            public SocketUtilException()
            {
            }
    
            public SocketUtilException(string message)
                : base(message)
            {
            }
    
            public SocketUtilException(string message, Exception inner)
                : base(message, inner)
            {
            }
    
            protected SocketUtilException(
                SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        public static class SocketUtil
        {
            private const int WSADESCRIPTION_LEN = 256;
    
            private const int WSASYSSTATUS_LEN = 128;
    
            [StructLayout(LayoutKind.Sequential)]
            public struct WSAData
            {
                public short wVersion;
                public short wHighVersion;
    
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WSADESCRIPTION_LEN+1)]
                public string szDescription;
    
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WSASYSSTATUS_LEN+1)]
                public string wSystemStatus;
                [Obsolete("Ignored when wVersionRequested >= 2.0")]
                public ushort wMaxSockets;
                [Obsolete("Ignored when wVersionRequested >= 2.0")]
                public ushort wMaxUdpDg;
                public IntPtr dwVendorInfo;
            }
    
            
            [StructLayoutAttribute(LayoutKind.Sequential)]
            public struct servent
            {
                public string s_name;
                public IntPtr s_aliases;
                public short s_port;
                public string s_proto;
            }
            
            private static ushort MakeWord ( byte low, byte high)
            {
                               
                return  (ushort)((ushort)(high << 8) | low);
            }
            
            [DllImport("ws2_32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
            private static extern int WSAStartup(ushort wVersionRequested, ref WSAData wsaData);
            [DllImport("ws2_32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
            private static extern int WSACleanup();
            [DllImport("ws2_32.dll",  SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern IntPtr getservbyname(string name, string proto);
            [DllImport("ws2_32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern IntPtr getservbyport(short port, string proto);
    
            public static int GetServiceByPort(short port, string protocol)
            {
                
                var wsaData = new WSAData();
                if (WSAStartup(MakeWord(2, 2), ref wsaData) != 0)
                {
                    throw new SocketUtilException("WSAStartup",
                        new SocketException(Marshal.GetLastWin32Error()));
    
                }
                try
                {
                    var netport = Convert.ToInt16(IPAddress.HostToNetworkOrder(port));
                    var result = getservbyport(netport, protocol);
                    if (IntPtr.Zero == result)
                    {
                        throw new SocketUtilException(
                            string.Format("Could not resolve service for port {0}", port),
                            new SocketException(Marshal.GetLastWin32Error()));
                    }
                    var srvent = (servent)Marshal.PtrToStructure(result, typeof(servent));
                    return Convert.ToInt32(IPAddress.NetworkToHostOrder(srvent.s_port));
                }
                finally
                {
                    WSACleanup();
                }
            }
    
            
            public static short GetServiceByName(string service, string protocol)
            {
                
                var wsaData = new WSAData();
                if(WSAStartup(MakeWord(2,2), ref wsaData) != 0)
                {
                    throw new SocketUtilException("WSAStartup", 
                        new SocketException(Marshal.GetLastWin32Error()));
    
                }
                try
                {
                    var result = getservbyname(service, protocol);
                    if (IntPtr.Zero == result)
                    {
                        throw new SocketUtilException(
                            string.Format("Could not resolve port for service {0}", service), 
                            new SocketException(Marshal.GetLastWin32Error()));
                    }
                    var srvent = (servent)Marshal.PtrToStructure(result, typeof(servent));
                    return Convert.ToInt16(IPAddress.NetworkToHostOrder(srvent.s_port));
                }
                finally
                {
                    WSACleanup();
                }
                
                
    
            }
        }
        class Program
        {
            
    
            static void Main(string[] args)
            {
    
                try
                {
    
                    
                    var port = SocketUtil.GetServiceByName("http", "tcp");
                    Console.WriteLine("http runs on port {0}", port);
                   
                    Console.WriteLine("Reverse call:{0}", SocketUtil.GetServiceByPort(port, "tcp"));
                    
                    
                   
                }
                catch(SocketUtilException exception)
                {
                    Console.WriteLine(exception.Message);
                    if(exception.InnerException != null)
                    {
                        Console.WriteLine(exception.InnerException.Message);
                    }
                }
                
    
            }
        }
