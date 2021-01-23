    Console.SetCursorPosition(0, 0); //setting initial place of cursor
    ConsoleKey key = Console.ReadKey(true).Key;
    int index = 0;
    while (key != ConsoleKey.Escape)  //untill i press escape
    {
        switch (key)
        {
            case ConsoleKey.DownArrow:   //for Down key
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Green;
                index = (index + 1) % files.Count;
                Console.SetCursorPosition(0, index);
                break;
            }
            key = Console.ReadKey(true).Key;
    }
