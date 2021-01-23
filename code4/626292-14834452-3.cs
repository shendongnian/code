    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var client = new ServiceReference1.Service1Client();
                Console.WriteLine(client.GetResponseData());
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    break;
            }
        }
    }
