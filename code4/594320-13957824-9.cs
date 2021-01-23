    static class Program
    {
        static void Main(string[] args)
        {
            var port = 12345;
            ThreadPool.QueueUserWorkItem(o => Server.Run(port, ProcessClientMessage));
            while (true)
            {
                Console.WriteLine("Enter a message to send and hit enter (or a blank line to exit)");
                var data = Console.ReadLine();
                if (string.IsNullOrEmpty(data)) break;
                Client.Run("localhost", port, data, m => Console.WriteLine("Client received server reply: {0}", m));
            }
        }
        private static string ProcessClientMessage(string clientMessage)
        {
            Console.WriteLine("Server received client message: {0}", clientMessage);
            // This callback would ordinarily process the client message, then return a string that will be sent back to the client in response.
            // For now, we'll just return a fixed string value...
            return "This is the server reply...";
        }
    }
