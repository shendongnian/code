    Fiddler.FiddlerApplication.BeforeRequest += sess =>
    {
        Console.WriteLine("REQUEST TO : " + sess.fullUrl);
        sess.bBufferResponse = true;
    };
    Fiddler.FiddlerApplication.Startup(8877, true, true);
    Console.ReadLine();
    Fiddler.FiddlerApplication.Shutdown();
    System.Threading.Thread.Sleep(750);
