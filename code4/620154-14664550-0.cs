    public static void StartProxy()
    {
        Fiddler.FiddlerApplication.BeforeRequest += sessionState =>
            {
                Console.WriteLine("URL={0}", sessionState.fullUrl);
            };
        Fiddler.FiddlerApplication.Startup(8888, true, true);
        Console.ReadLine();
        Fiddler.FiddlerApplication.Shutdown();
        System.Threading.Thread.Sleep(750);
    }
