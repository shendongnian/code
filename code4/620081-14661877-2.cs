    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NetworkCommsDotNet;
    
    namespace UPDServer
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", (packetHeader, connection, incomingString) => 
                {
                    Console.WriteLine("This is the message you received " + incomingString);
                    connection.SendObject("Message", incomingString + " relayed by server.");
                });
    
                UDPConnection.StartListening(true);
    
                Console.WriteLine("Server ready. Press any key to shutdown server.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
