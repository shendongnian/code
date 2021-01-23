    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting server..");
    
                Parallel.ForEach(
                    new[] {new Connection(TimeSpan.FromSeconds(1)), new Connection(TimeSpan.FromSeconds(1))},
                    connection => ThreadPool.QueueUserWorkItem(connection.Connect));
                    
                Console.WriteLine("Server running. Press Enter to quit.");
                    
                Console.ReadLine();
            }
        }
    
        public class Connection //might be good to implement IDisposable and disconnect on Dipose()
        {
            private readonly TimeSpan _reConnectionPause;
    
            public Connection(TimeSpan reConnectionPause)
            {
                _reConnectionPause = reConnectionPause;
            }
    
            //You probably need a Disconnect too
            public void Connect(object state)
            {
                try
                {
                    //for testing assume connection success Client.Connect(IRCHelper.SERVER, IRCHelper.PORT);
                    Debug.WriteLine("Open Connection");
                }
                catch (Exception)
                {
                    //You might want a retry limit here
                    Connect(state);
                }
    
                try
                {
                    //Client.Listen();
                    //Simulate sesison lifetime
                    Thread.Sleep(1000);
                    throw new Exception();
                }
                catch (Exception)
                {
                    Debug.WriteLine("Session end");
                    Thread.Sleep(_reConnectionPause);
                    Connect(state);
                }
            }
        }
    }
