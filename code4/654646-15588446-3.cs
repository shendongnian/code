    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    
    using NetworkCommsDotNet;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkComms.AppendGlobalIncomingPacketHandler<object>("ThreadIdRequest", (packetHeader, connection, incomingPlayer) =>
                {
                    //Reply with the requested threadIds
                    Console.WriteLine("Received thread ID request from {0}.", connection.ToString());
                    connection.SendObject("ThreadIds", TaskManager().ToArray());
                });
    
                //Start listening for incoming TCP Connections
                TCPConnection.StartListening(true);
    
                Console.WriteLine("Server ready. Press any key to shutdown server.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
    
            private static IEnumerable<string> TaskManager()
            {
                List<string> lst = new List<string>();
    
                foreach (System.Diagnostics.Process p in
                Process.GetProcesses().OrderBy(o => o.ProcessName))
                {
                    lst.Add(p.ProcessName + "_" + p.Id);
                }
                return lst.AsParallel();
            }
        }
    }
