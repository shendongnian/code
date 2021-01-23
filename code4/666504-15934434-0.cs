    private static void Main()
    {
        PrintTimes();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Some text is being printed");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
        Console.WriteLine("press any key to exit . . .");
        Console.ReadKey();
    }
    private static async void PrintTimes()
    {
        int line = Console.CursorTop;
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            int previousLine = Console.CursorTop;
            int previousChar = Console.CursorLeft;
            Console.CursorTop = line;
            Console.CursorLeft = 0;
            Console.WriteLine("{0}% left       ", 100 - i * 10);
            Console.CursorTop = previousLine;
            Console.CursorLeft = previousChar;
            await Task.Delay(1000);
        }
    }
