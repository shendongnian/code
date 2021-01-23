    class Program
    {
        public static JSONServer srv = null;
        static void Main(string[] args)
        {
            Console.WriteLine("NLPS Core Server");
            srv = new JSONServer(100);
            srv.Start();
            InputLoopProcessor();
            while(srv.IsRunning)
            {
                Thread.Sleep(250);
            }
        }
        private static async Task InputLoopProcessor()
        {
            string line = "";
            Console.WriteLine("Core NLPS Server: Started on port 8080. " + DateTime.Now);
            while(line != "quit")
            {
                Console.Write(": ");
                line = Console.ReadLine().ToLower();
                Console.WriteLine(line);
                if(line == "?" || line == "help")
                {
                    Console.WriteLine("Core NLPS Server Help");
                    Console.WriteLine("    ? or help: Show this help.");
                    Console.WriteLine("    quit: Stop the server.");
                }
            }
            srv.Stop();
            Console.WriteLine("Core Processor done at " + DateTime.Now);
        }
    }
