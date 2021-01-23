    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NetworkCommsDotNet;
    
    namespace UDPClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                string messageToSend = "This is a message To Send";
                string messageFromServer = UDPConnection.GetConnection(new ConnectionInfo("127.0.0.1", 10000), UDPOptions.None).SendReceiveObject<string>("Message", "Message", 2000, messageToSend);
                Console.WriteLine("Server said '{0}'.", messageFromServer);
    
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
