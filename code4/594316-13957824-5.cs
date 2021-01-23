    static class Program
    {
        static void Main(string[] args)
        {
            var port = 12345;
            ThreadPool.QueueUserWorkItem(o => Server.Run(port, m => Console.WriteLine("Received message: {0}", m)));
            while (true)
            {
                Console.WriteLine("Enter a message to send and hit enter (or a blank line to exit)");
                var data = Console.ReadLine();
                if (string.IsNullOrEmpty(data)) break;
                Client.Run(port, data);
            }
        }
    }
