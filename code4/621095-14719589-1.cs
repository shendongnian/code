    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NetworkCommsDotNet;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkComms.AppendGlobalIncomingPacketHandler<byte[]>("XMLData", (packetHeader, connection, incomingXMLData) => 
                {
                        Console.WriteLine("Received XMLData");
                        File.WriteAllBytes("filename.xml", incomingXMLData);
                });
    
                TCPConnection.StartListening(true);
    
                Console.WriteLine("Server ready. Press any key to shutdown server.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
