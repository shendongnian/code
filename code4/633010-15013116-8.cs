    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    using NetworkCommsDotNet;
    using ProtoBuf;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Convert incoming data to a <Player> object and run this method when an incoming packet is received.
                NetworkComms.AppendGlobalIncomingPacketHandler<Player>("PlayerData", (packetHeader, connection, incomingPlayer) =>
                {
                    Console.WriteLine("Received player data. Player name was " + incomingPlayer.Name);
                    //Do anything else with the player object here
                    //e.g. UpdatePlayerPosition(incomingPlayer);
                });
    
                //Listen for incoming connections
                TCPConnection.StartListening(true);
    
                Console.WriteLine("Server ready. Press any key to shutdown server.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
