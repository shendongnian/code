    int width = Console.WindowWidth;
    int height = Console.WindowHeight;
    int i, j;
    for (i = 0; i < width; ++i)
    {
        Console.Write("-");
    }
    for (j = 0; j < height - 2; ++j)
    {
        Console.Write("|");
        for (i = 0; i < width - 2; ++i)
        {
            Console.Write(" ");
        }
        Console.Write("|");
    }
    //enlarge window in order to prevent it from being scrolled
    Console.WindowHeight += 1;
    for (i = 0; i < width; ++i)
    {
        Console.Write("-");
    }
    //restore window's original size
    Console.WindowHeight -= 1;
    //set cursor inside the border
    Console.SetCursorPosition(1, 1);
