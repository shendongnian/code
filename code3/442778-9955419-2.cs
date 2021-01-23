    Console.WriteLine("Press a key to start (Enter to stop).");
    
    var key = Console.ReadKey();
    var allKeys = "";
    
    while(key.Key != ConsoleKey.Enter)
    {
        Console.WriteLine(key.KeyChar);
        allKeys += key.KeyChar;
        key = Console.ReadKey();
    }
