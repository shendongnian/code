    public static void SetBG(string s)
    {
        ConsoleColor color;
        if (!Enum.TryParse<ConsoleColor>(s, out color))
            throw new ArgumentException("s");
        Console.BackgroundColor = color;
    }
