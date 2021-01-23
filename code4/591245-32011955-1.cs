    lock (Console.Out)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t" + text);
        Console.ForegroundColor = ConsoleColor.White;
    }
