    private static Random _random = new Random();
    private static ConsoleColor GetRandomConsoleColor()
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
    }
    private static void Main(string[] args)
    {
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine("Hello World!");
    }
