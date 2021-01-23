    using System;
    using System.IO.Pipes;
    using System.Threading.Tasks;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                var server = new NamedPipeServerStream("A", PipeDirection.InOut);
                server.WaitForConnection();
    
                for (int i =0; i < 10000; i++)
                {
                    var b = new byte[1];
                    server.Read(b, 0, 1); 
                    Console.WriteLine("Read Byte:" + b[0]);
                    server.Write(b, 0, 1);
                }
            }
        }
    }
