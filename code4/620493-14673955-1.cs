    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NetworkCommsDotNet;
    
    namespace TCPClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                string messageToSend = "This is the message to send";
                TCPConnection.GetConnection(new ConnectionInfo("127.0.0.1", 10000)).SendObject("Message", messageToSend);
                Console.WriteLine("Press any key to exit client.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
