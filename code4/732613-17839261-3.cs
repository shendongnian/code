    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Sockets;
    using System.Timers;
    using System.IO;
    using System.Net;
    using System.Threading;
    namespace testbed
    {
    static class Program
    {
        //static ManualResetEvent tcpClientConnected =new ManualResetEvent(false);
        static void Main()
        {
            var s2 = new TcpListener(9998);
            s2.Start();
            while (true)
            {
                if (s2.Pending())
                {
                    Thread test = new Thread(() =>
                    {
                        using (TcpClient client = s2.AcceptTcpClient())
                        {
                            Blah(client);
                        }
                    });
                    test.Start();
                    //tcpClientConnected.WaitOne();
                }
                Thread.Sleep(10);
            }
        }
        static void Blah(TcpClient listener)
        {
            try
            {
                Console.WriteLine("Connection");
                //TcpListener listener = (TcpListener)ar.AsyncState;
                //tcpClientConnected.Set();
                var ns1 = listener.GetStream();
                var r1 = new BinaryReader(ns1);
                var w1 = new BinaryWriter(ns1);
                if (false)
                {
                    var s3 = new TcpClient();
                    s3.Connect("127.0.0.1", 9150);
                    var ns3 = s3.GetStream();
                    var r3 = new BinaryReader(ns3);
                    var w3 = new BinaryWriter(ns3);
                    while (true)
                    {
                        while (ns1.DataAvailable)
                        {
                            var b = ns1.ReadByte();
                            w3.Write((byte)b);
                            //Console.WriteLine("1: {0}", b);
                        }
                        while (ns3.DataAvailable)
                        {
                            var b = ns3.ReadByte();
                            w1.Write((byte)b);
                            Console.WriteLine("2: {0}", b);
                        }
                    }
                }
                {
                    if (!(r1.ReadByte() == 5 && r1.ReadByte() == 1))
                        return;
                    var c = r1.ReadByte();
                    for (int i = 0; i < c; ++i)
                        r1.ReadByte();
                    w1.Write((byte)5);
                    w1.Write((byte)0);
                }
                {
                    if (!(r1.ReadByte() == 5 && r1.ReadByte() == 1))
                        return;
                    if (r1.ReadByte() != 0)
                        return;
                }
                byte[] ipAddr = null;
                string hostname = null;
                var type = r1.ReadByte();
                switch (type)
                {
                    case 1:
                        ipAddr = r1.ReadBytes(4);
                        break;
                    case 3:
                        hostname = Encoding.ASCII.GetString(r1.ReadBytes(r1.ReadByte()));
                        break;
                    case 4:
                        throw new Exception();
                }
                var nhport = r1.ReadInt16();
                var port = IPAddress.NetworkToHostOrder(nhport);
                var socketout = new TcpClient();
                if (hostname != null)
                    socketout.Connect(hostname, port);
                else
                    socketout.Connect(new IPAddress(ipAddr), port);
                w1.Write((byte)5);
                w1.Write((byte)0);
                w1.Write((byte)0);
                w1.Write(type);
                switch (type)
                {
                    case 1:
                        w1.Write(ipAddr);
                        break;
                    case 2:
                        w1.Write((byte)hostname.Length);
                        w1.Write(Encoding.ASCII.GetBytes(hostname), 0, hostname.Length);
                        break;
                }
                w1.Write(nhport);
                var buf1 = new byte[4096];
                var buf2 = new byte[4096];
                var ns2 = socketout.GetStream();
                var r2 = new BinaryReader(ns2);
                var w2 = new BinaryWriter(ns2);
                while (ns1.CanRead && ns1.CanWrite && ns2.CanRead && ns2.CanWrite)
                {
                    if (ns1.DataAvailable)
                    {
                        int size = ns1.Read(buf1, 0, buf1.Length);
                        ns2.Write(buf1, 0, size);
                    }
                    if (ns2.DataAvailable)
                    {
                        int size = ns2.Read(buf2, 0, buf2.Length);
                        ns1.Write(buf2, 0, size);
                    }
                    Thread.Sleep(10);
                }
            }
            catch { }
        }
    }
    }
