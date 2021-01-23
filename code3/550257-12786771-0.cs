    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ping = new Ping();
    
                var reply = ping.Send(IPAddress.Loopback);
    
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Pinging with server: " + reply.Address);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
            }
        }
    }
