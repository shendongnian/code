    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Net.Sockets;
    using System.Net;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static StreamReader reader;
            private static StreamWriter writer;
    
            static void Main(string[] args)
            {
                //Server initialisation 
    
                Process cmdServer = new Process();
    
                cmdServer.StartInfo.FileName = "cmd.exe";
                cmdServer.StartInfo.RedirectStandardInput = true;
                cmdServer.StartInfo.RedirectStandardOutput = true;
                cmdServer.StartInfo.UseShellExecute = false;
    
                cmdServer.Start();
    
                reader = cmdServer.StandardOutput;
                writer = cmdServer.StandardInput;
    
    
                Thread t1 = new Thread(new ThreadStart(clientListener));
                t1.Start();
                Thread t2 = new Thread(new ThreadStart(clientWriter));
                t2.Start();
                Thread t3 = new Thread(new ThreadStart(serverListener));
                t3.Start();
                Thread t4 = new Thread(new ThreadStart(serverWriter));
                t4.Start();
    
    
            }
    
            public static void clientWriter()
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                Int32 size = 0;
                Byte[] buff = new Byte[1024];
    
                sock.Connect(IPAddress.Parse("127.0.0.1"), 4357);
                Console.WriteLine("clientWriter connected");
    
                while (true)
                {
                    String line = Console.ReadLine();
                    line += "\n";
                    Char[] chars = line.ToArray();
                    size = chars.Length;
                    if (size > 0)
                    {
                        buff = Encoding.Default.GetBytes(chars);
                        //Console.WriteLine("Sending \"" + new String(chars, 0, size) + "\"");
                        sock.Send(buff, size, 0);
                    }
                }
            }
    
            /// <summary>
            /// Local client that listens to what the server sends on port 4356
            /// </summary>
            public static void clientListener()
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                sock.Bind(new IPEndPoint(IPAddress.Any, 4356));
                sock.Listen(0);
    
                Int32 size = 0;
                Byte[] buff = new Byte[1024];
                Char[] cbuff = new Char[1024];
    
                while (true)
                {
                    Console.WriteLine("clientListener Waiting for connection");
                    sock = sock.Accept();
                    Console.WriteLine("clientListener Connection accepted " + ((sock.Connected)?"Connected" : "Not Connected"));
    
                    while ((size = sock.Receive(buff)) > 0)
                    {
                        for (int i = 0; i < size; i++) cbuff[i] = (Char)buff[i];
                        Console.Write(cbuff, 0, size);
                    }
    
                    sock.Close();
    
                }
            }
    
            /// <summary>
            /// Remote server that listens to what the client sends on port 4357
            /// </summary>
            public static void serverListener()
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                sock.Bind(new IPEndPoint(IPAddress.Any, 4357));
                sock.Listen(0);
    
                Int32 size = 0;
                Byte[] buff = new Byte[1024];
                Char[] cbuff = new Char[1024];
    
                while (true)
                {
                    Console.WriteLine("serverListener Waiting for connection");
                    sock = sock.Accept();
                    Console.WriteLine("serverListener Connection accepted " + ((sock.Connected) ? "Connected" : "Not Connected"));
                    
                    while ((size = sock.Receive(buff)) > 0)
                    {
                        for (int i = 0; i < size; i++) cbuff[i] = (Char)buff[i];
                        //Console.WriteLine("Received \"" + new String(cbuff,0,size) + "\"");
                        writer.Write(cbuff, 0, size);
                    }
    
                }
            }
    
            /// <summary>
            /// Remote server that writes the output of the colsole application through the socket
            /// </summary>
            public static void serverWriter()
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                Int32 size = 0;
                Byte[] buff = new Byte[1024];
                Char[] cbuff = new Char[1024];
    
                sock.Connect(IPAddress.Parse("127.0.0.1"), 4356);
    
                Console.WriteLine("serverWriter connected");
    
                while (true)
                {
                    size = reader.Read(cbuff, 0, 1024);
                    if (size > 0)
                    {
                        for (int i = 0; i < size; i++) buff[i] = (Byte)cbuff[i];
                        sock.Send(buff, 0, size, 0);
                    }
                }
            }
        }
    }
