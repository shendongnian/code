    void ErrorLine(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.Error.WriteLine(text);
        Console.ResetColor();
    }
    void OutputLine(string text)
    {
        Console.Error.WriteLine(text);
    }
