        using System;
        using System.Net.Sockets;
        using System.IO;
        using System.Threading;
        
        namespace Server
        {
            class Program
            {
                static void Main(string[] args)
                {
                    TcpListener server = new TcpListener(5000);
                    server.Start();
                    Console.WriteLine("Server Started at {0}",DateTime.Now.ToString());
                    while (true)
                    {
                        Socket client = server.AcceptSocket();
                        Thread th = new Thread(ProcessSocket);
                        th.Start(client);
                    }
        
                }
                public static void ProcessSocket(object o)
                {
                    Socket client = (Socket)o;
                    NetworkStream nws = new NetworkStream(client);
                    StreamReader sr = new StreamReader(nws);
                    while(client.Connected)
                    {
                        string s = sr.ReadLine();
                        Console.WriteLine(" Message from {0} is :{1}", client.LocalEndPoint.ToString(), s);
                    }
                }
            }
        }
