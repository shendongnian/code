    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Data to return
            byte[] ret = { 0xfe, 0xfd, 0x09, 0x00, 0x00, 0x00, 0x00 };
    
            // tell the user that we are waiting
            Console.WriteLine("Waiting for UDP Connection...");
    
            // Create a new socket to listen from
            Socket Skt = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Skt.EnableBroadcast = true;
            Skt.Bind(new IPEndPoint(IPAddress.Loopback, 27900));
    
            try
            {
                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = new byte[48];
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
    
                Thread thr = new Thread(new ThreadStart(Test));
                thr.Start();
                Skt.ReceiveFrom(receiveBytes, ref senderRemote);
                string returnData = Encoding.UTF8.GetString(receiveBytes).Trim();
    
                Console.WriteLine("This is the message you received " + returnData.ToString());
    
                // Sent return data
                int sent = Skt.SendTo(ret, senderRemote);
                Console.WriteLine("Sent {0} bytes back", sent);
                Skt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
    
            Console.ReadLine();
        
            }
    
    
    
            public static void Test()
            {
                byte[] ret = { 0xfe, 0xfd, 0x09, 0x00, 0x00, 0x00, 0x00 };
                Socket Skt = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Skt.EnableBroadcast = true;
                IPEndPoint test=new IPEndPoint(IPAddress.Loopback, 27900);
    
                int sent = Skt.SendTo(ret, test);
                try
                {
                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = new byte[48];
                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint senderRemote = (EndPoint)sender;
    
                    Skt.ReceiveFrom(receiveBytes, ref senderRemote);
                    string returnData = Encoding.UTF8.GetString(receiveBytes).Trim();
    
                    Console.WriteLine("This is the message you received " + returnData.ToString());
    
                    // Sent return data
                    //int sent = Skt.SendTo(ret, senderRemote);
                    Console.WriteLine("Sent {0} bytes back", sent);
                    Skt.Close();
    
    
    
                }
                catch (Exception ex)
                {
                }
            }
            
        }
    }
   
