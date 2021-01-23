    //from 1.2.3.1 to  1.2.3.254
    var hosts = StackOverflow.Pinger.PingAll("1.2.3.1-254");
     //from 1.2.3.1 to  1.2.3.254 and   from 1.2.5.1 to  1.2.5.254
    var hosts = StackOverflow.Pinger.PingAll("1.2.3,5.1-254");
---
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    namespace StackOverflow
    {
        public static class Pinger
        {
            static byte ICMP_ECHO = 8;
            static byte ICMP_ECHOREPLY = 0;
            static int OFFSET_ID = 4;
            static int OFFSET_CHECKSUM = 2;
            static int IP_HEADER_LEN = 20;
            static int ICMP_HEADER_LEN = 8;
        
            /**************************************************************
             *  Example Usages:
             *  
             *  PingAll("1.2.3.4")       => 1.2.3.4
             *  PingAll("1.2.3.1-255")   => 1.2.3.X
             *  PingAll("1.2.3,7.1-255") => 1.2.3.X and 1.2.7.X
             *  PingAll("1.2.3-5.1-255") => 1.2.3.X and 1.2.4.X and 1.2.5.X
             **************************************************************/
            public static IEnumerable<Host> PingAll(string subNets, int timeOut = 1500)
            {
                ushort PACKET_ID = (ushort)new Random().Next(0, ushort.MaxValue);
                //Init
                Socket rawSock = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                rawSock.Bind(new IPEndPoint(IPAddress.Any, 0));
                rawSock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IpTimeToLive, 255);
                rawSock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, Int32.MaxValue);
                rawSock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Int32.MaxValue);
                rawSock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, false);
                HashSet<Host> aliveIPs = new HashSet<Host>();
                //** Receiver **
                Task receiver = Task.Factory.StartNew(() =>
                {
                    byte[] bytesRecv = new byte[0x10000];
                    EndPoint remoteAddr = new IPEndPoint(IPAddress.Any, 0);
                    while (true)
                    {
                        try
                        {
                            rawSock.ReceiveFrom(bytesRecv, ref remoteAddr);
                        }
                        catch { return; };
                        ushort replyId = BitConverter.ToUInt16(bytesRecv, IP_HEADER_LEN + OFFSET_ID);
                        if (bytesRecv[IP_HEADER_LEN] == ICMP_ECHOREPLY && replyId == PACKET_ID)
                        {
                            long ticksInPong = BitConverter.ToInt64(bytesRecv, IP_HEADER_LEN + ICMP_HEADER_LEN);
                            int duration = (int)((DateTime.Now.Ticks - ticksInPong) / TimeSpan.TicksPerMillisecond);
                            var host = new Host(((IPEndPoint)remoteAddr).Address.ToString(), duration);
                            //Console.WriteLine(host.IP + "\t:\t" + host.Duration);
                            lock (aliveIPs)
                            {
                                aliveIPs.Add(host);
                            }
                        }
                    }
                }, TaskCreationOptions.LongRunning);
                Task.Yield(); //Give a chance to listener task to start.
                //** Sender **
                for (int j = 0; j < 2; j++)//Send Ping packets twice
                {
                    foreach (var ip in GetIPAddresses(subNets))
                    {
                        byte[] packet = CreatePacket(PACKET_ID, BitConverter.GetBytes(DateTime.Now.Ticks));
                        IPEndPoint dest = new IPEndPoint(IPAddress.Parse(ip), 0);
                        try
                        {
                            rawSock.SendTo(packet, dest);
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message + "\n==>" + ip);
                        }
                    }
                    Task.Delay(timeOut / 3).Wait();
                }
                Task.WaitAny(receiver, Task.Delay(timeOut));
                rawSock.Close();
                return aliveIPs;
            }
            public static Task<IEnumerable<Host>> PingAllAsync(string subNets, int TimeOut = 1500)
            {
                return Task.Run(() => PingAll(subNets, TimeOut));
            }
            static byte[] CreatePacket(ushort id, byte[] data)
            {
                byte[] packet = new byte[ICMP_HEADER_LEN + data.Length];
                packet[0] = ICMP_ECHO;
                Array.Copy(BitConverter.GetBytes(id), 0, packet, OFFSET_ID, 2); //copy id
                Array.Copy(data, 0, packet, ICMP_HEADER_LEN, data.Length); //copy data
                Array.Copy(BitConverter.GetBytes(GetChecksum(packet)), 0, packet, OFFSET_CHECKSUM, 2); //copy checksum
                return packet;
            }
            static ushort GetChecksum(byte[] bytes)
            {
                ulong sum = 0;
                int i;
                for (i = 0; i < bytes.Length - 1; i += 2)
                {
                    sum += BitConverter.ToUInt16(bytes, i);
                }
                if (i != bytes.Length)
                    sum += bytes[i];
                sum = (sum >> 16) + (sum & 0xFFFF);
                sum += (sum >> 16);
                return (ushort)(~sum);
            }
            static IEnumerable<string> GetIPAddresses(string ip)
            {
                string[] parts = ip.Split('.');
                if (parts.Length != 4) throw new FormatException("Invalid format");
                return
                    from p1 in GetRange(parts[0])
                    from p2 in GetRange(parts[1])
                    from p3 in GetRange(parts[2])
                    from p4 in GetRange(parts[3])
                    select String.Format("{0}.{1}.{2}.{3}", p1, p2, p3, p4);
            }
            static IEnumerable<int> GetRange(string s)
            {
                foreach (var part in s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var range = part.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (range.Length > 2) throw new FormatException(String.Format("Invalid Format \"{0}\"", range));
                    if (range.Length == 1) yield return int.Parse(range[0]);
                    else
                    {
                        for (int i = int.Parse(range[0]); i <= int.Parse(range[1]); i++)
                        {
                            yield return i;
                        }
                    }
                }
            }
            public class Host
            {
                public string IP { get; private set; }
                public int Duration { get; private set; }
                public Host(string IP, int duration)
                {
                    this.IP = IP;
                    this.Duration = duration;
                }
                public override bool Equals(object obj)
                {
                    return IP.Equals((obj as Host).IP);
                }
                public override int GetHashCode()
                {
                    return IP.GetHashCode();
                }
                public override string ToString()
                {
                    return IP;
                }
            }
        }
    }
