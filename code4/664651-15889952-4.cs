    class Program
    {
        static void Main(string[] args)
        {
            var appHost = new AppHost();
            appHost.Init();
            appHost.Start("http://*:1337/");
            System.Console.WriteLine("Listening on http://localhost:1337/ ...");
            System.Console.ReadLine();
			System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
		}
    }
