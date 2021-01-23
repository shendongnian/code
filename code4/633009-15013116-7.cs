    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    using NetworkCommsDotNet;
    using ProtoBuf;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                Player player = new Player("MarcF", 100, "09.09N,21.12W");
    
                //Could also use UDPConnection.GetConnection...
                TCPConnection.GetConnection(new ConnectionInfo("127.0.0.1", 10000)).SendObject("PlayerData", player);
    
                Console.WriteLine("Send completed. Press any key to exit client.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
