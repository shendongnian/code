    using System;
    using NetworkCommsDotNet;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create a connection
                Connection connection = TCPConnection.GetConnection(new ConnectionInfo("127.0.0.1", 10000));
    
                //Make a request for the threadIds and get the answer in one statement. 
                string[] taskManagerThreadIds = connection.SendReceiveObject<string[]>("ThreadIdRequest", "ThreadIds", 2000);
    
                Console.WriteLine("Server provided an array containing {0} ids", taskManagerThreadIds.Length);
    
                Console.WriteLine("Send completed. Press any key to exit client.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
