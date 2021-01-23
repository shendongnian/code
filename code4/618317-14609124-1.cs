    int spaces = 0;
    ConsoleKey key;
    do
    {
        key = Console.ReadKey().Key;
        if (key == ConsoleKey.Spacebar)
            spaces++;
    }
    while (key != ConsoleKey.OemPeriod);
    Console.WriteLine("Number of spaces counted = {0}",spaces);
