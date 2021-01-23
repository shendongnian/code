    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine(""); // Just to separate inputs and output on screen.
    
        if (key.Key == ConsoleKey.N)
        {
            Console.WriteLine("\nNO");
            break;
        }
    
        if (key.Key == ConsoleKey.Y)
        {
            Console.WriteLine("\nYES");
            break;
        }                
    }
