    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    
    namespace AClient
    {
        class Client
        {
            static void Main()
            {
                using (var client = new TcpClient("localhost", 8888))
                {
                    Console.WriteLine(">> Client Started");
    
                    using (var r = new StreamReader(@"E:\input.txt", Encoding.UTF8))
                    using (var w = new StreamWriter(client.GetStream(), Encoding.UTF8))
                    {
                        string line;
                        while (null != (line = r.ReadLine()))
                        {
                            w.WriteLine(line);
                            w.Flush(); // probably not necessary, but I'm too lazy to find the docs
                        }
                    }
    
                    Console.WriteLine(">> Goodbye");
                }
            }
        }
    }
