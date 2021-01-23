    static void Main(string[] args)
        {
            Server();
        }
        static void Server()
        {
            Console.WriteLine("Server started...");
            var httpChannel = new HttpChannel(9998);
            ChannelServices.RegisterChannel(httpChannel);
