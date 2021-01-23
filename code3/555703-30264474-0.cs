    public void Scan(string username, string apiKey, string url)
    {
        // Login to Copyleaks server.
        Console.Write("User login... ");
        LoginToken token = UsersAuthentication.Login(username, apiKey);
        Console.WriteLine("\t\t\tSuccess!");
    
        // Create a new process on server.
        Console.Write("Submiting new request... ");
        Detector detector = new Detector(token);
        ScannerProcess process = detector.CreateProcess(url);
        Console.WriteLine("\tSuccess!");
    
        // Waiting to process to be finished.
        Console.Write("Waiting for completion... ");
        while (!process.IsCompleted())
            Thread.Sleep(1000);
        Console.WriteLine("\tSuccess!");
    
        // Getting results.
        Console.Write("Getting results... ");
        var results = process.GetResults();
        if (results.Length == 0)
        {
            Console.WriteLine("\tNo results.");
        }
        else
        {
            for (int i = 0; i < results.Length; ++i)
            {
                Console.WriteLine();
                Console.WriteLine("Result {0}:", i + 1);
                Console.WriteLine("Domain: {0}", results[i].Domain);
                Console.WriteLine("Url: {0}", results[i].URL);
                Console.WriteLine("Precents: {0}", results[i].Precents);
                Console.WriteLine("CopiedWords: {0}", results[i].NumberOfCopiedWords);
            }
        }
    }
