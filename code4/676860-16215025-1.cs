    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Any, 12343);
            var thread = new Thread(() => AsyncAccept(listener));
            thread.Start();
            Console.WriteLine("Press enter to stop...");
            Console.ReadLine();
            Console.WriteLine("Stopping listener...");
            listener.Stop();
            thread.Join();
        }
        private static void AsyncAccept(TcpListener listener)
        {
            listener.Start();
            Console.WriteLine("Started listener");
            try
            {
                while (true)
                {
                    using (var client = listener.AcceptTcpClient())
                    {
                        Console.WriteLine("Accepted client: {0}", client.Client.RemoteEndPoint);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Listener done");
        }
    }
