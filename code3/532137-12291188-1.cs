    static void Main(string[] args)
    {
        SubscriberClient client = new SubscriberClient();
        client.Subscribe("SlateQueueElements", () => 
        {
           Console.WriteLine("Calling back...");
        });
    
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    
            if (keyInfo.Key == ConsoleKey.X)
                break;
        }
    }
