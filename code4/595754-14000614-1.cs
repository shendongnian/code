    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine(""); // Just for nice typesetting.
        if (key.Key == ConsoleKey.N)
        {
            Console.WriteLine("NO");
            break;
        }
        if (key.Key == ConsoleKey.Y)
        {
            Console.WriteLine("YES");
            break;
        }
    }
