    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    namespace SimpleClient
    {
        internal class Client
        {
            private static void Main(string[] args)
            {
                try
                {
                    TcpClient client = new TcpClient();
                    NetworkStream ns;
                    client.Connect("127.0.0.1", 560);
                    ns = client.GetStream();
                    byte[] buffer = ReadNBytes(ns, 4);
                        // read out the length field we know is there, because the server always sends it.
                    int msgLenth = BitConverter.ToInt32(buffer, 0);
                    buffer = ReadNBytes(ns, msgLenth);
                    //working with the buffer...
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string msg = encoder.GetString(buffer);
                    Console.WriteLine(msg);
                    client.Close();
                }
                catch
                {
                    //displaying error...
                }
            }
            public static byte[] ReadNBytes(NetworkStream stream, int n)
            {
                byte[] buffer = new byte[n];
                int bytesRead = 0;
    
                int chunk;
                while (bytesRead < n)
                {
                    chunk = stream.Read(buffer, (int) bytesRead, buffer.Length - (int) bytesRead);
                    if (chunk == 0)
                    {
                        // error out
                        throw new Exception("Unexpected disconnect");
                    }
                    bytesRead += chunk;
                }
                return buffer;
            }
        }
    }
