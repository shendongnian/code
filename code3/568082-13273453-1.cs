    namespace SocketUtil
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
    
            
            [DllImport("libc",  SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern IntPtr getservbyname(string name, string proto);
            [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern IntPtr getservbyport(short port, string proto);
    
            public static string GetServiceByPort(short port, string protocol)
            {
    
            
           
                var netport = Convert.ToInt16(IPAddress.HostToNetworkOrder(port));
                var result = getservbyport(netport, protocol);
                if (IntPtr.Zero == result)
                {
                    throw new SocketUtilException(
                        string.Format("Could not resolve service for port {0}", port));
                }
                var srvent = (servent)Marshal.PtrToStructure(result, typeof(servent));
                return srvent.s_name;;
                
            }
    
    
            public static short GetServiceByName(string service, string protocol)
            {
    
                var result = getservbyname(service, protocol);
                if (IntPtr.Zero == result)
                {
                    throw new SocketUtilException(
                        string.Format("Could not resolve port for service {0}", service));
                }
                var srvent = (servent)Marshal.PtrToStructure(result, typeof(servent));
                return Convert.ToInt16(IPAddress.NetworkToHostOrder(srvent.s_port));
     
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
    }
