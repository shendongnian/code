    using System;
    using System.Net.Sockets;
    using System.IO;
    
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpClient  client = new TcpClient();
                client.Connect("IP/Hostname", 5000);
                NetworkStream nws = new NetworkStream(client.Client);
                StreamWriter sw = new StreamWriter(nws);
                while (client.Connected)
                {
                    Console.Write("your Message:");
                    string s=Console.ReadLine();
                    sw.WriteLine(s);
                    sw.Flush();
                    Console.WriteLine("Message sent to server");
                }
    
            }
        }
    }
