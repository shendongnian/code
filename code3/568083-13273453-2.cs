    namespace SocketUtil
    {
        using System;
        using System.Net;
        using System.Collections.Generic;
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
                public ushort s_port;
                public string s_proto;
            }
    
    
            [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern IntPtr getservbyname(string name, string proto);
            [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern IntPtr getservbyport(ushort port, string proto);
    
            public static string GetServiceByPort(ushort port, string protocol, out List<string> aliases)
            {
                var netport = unchecked((ushort)IPAddress.HostToNetworkOrder(unchecked((short)port)));
                var result = getservbyport(netport, protocol);
                if (IntPtr.Zero == result)
                {
                    throw new SocketUtilException(
                        string.Format("Could not resolve service for port {0}", port));
                }
                var srvent = (servent)Marshal.PtrToStructure(result, typeof(servent));
                aliases = GetAliases(srvent);
                return srvent.s_name;
    
            }
    
            private static List<string> GetAliases(servent srvent)
            {
                var aliases = new List<string>();
                if (srvent.s_aliases != IntPtr.Zero)
                {
                    IntPtr cb;
    
                    for (var i = 0;
                        (cb = Marshal.ReadIntPtr(srvent.s_aliases, i)) != IntPtr.Zero;
                        i += Marshal.SizeOf(cb))
                    {
                        aliases.Add(Marshal.PtrToStringAnsi(cb));
                    }
                }
                return aliases;
            }
    
            public static ushort GetServiceByName(string service, string protocol, out List<string> aliases)
            {
    
                var result = getservbyname(service, protocol);
                if (IntPtr.Zero == result)
                {
                    throw new SocketUtilException(
                        string.Format("Could not resolve port for service {0}", service));
                }
    
                var srvent = (servent)Marshal.PtrToStructure(result, typeof(servent));
                aliases = GetAliases(srvent);
                var hostport = IPAddress.NetworkToHostOrder(unchecked((short)srvent.s_port));
                return unchecked((ushort)hostport);
    
            }
        }
        class Program
        {
    
            static void Main(string[] args)
            {
    
                try
                {
                    List<string> aliases;
                    var port = SocketUtil.GetServiceByName("https", "tcp", out aliases);
    
                    Console.WriteLine("https runs on port {0}", port);
                    foreach (var alias in aliases)
                    {
                        Console.WriteLine(alias);
                    }
    
                    Console.WriteLine("Reverse call:{0}", SocketUtil.GetServiceByPort(port, "tcp", out aliases));
    
                }
                catch (SocketUtilException exception)
                {
                    Console.WriteLine(exception.Message);
                    if (exception.InnerException != null)
                    {
                        Console.WriteLine(exception.InnerException.Message);
                    }
                }
    
            }
        }
    }
