    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Server1.Server.Start();
                Server2.Server.Start();
                Console.WriteLine("servers started...");
                Console.Read();
            }
        }
    }
