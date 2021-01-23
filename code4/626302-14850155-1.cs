    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var client = new ServiceReference1.Service1Client();
                client.TimeBuffer = 150;
                Console.WriteLine(client.GetResponseData().Result);
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    break;
            }
        }
    }
