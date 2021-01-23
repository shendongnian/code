    // Store these as static variables; they will never be changing
    String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
    int numColors = colorNames.Length;
    
    // ...
    Random rand = new Random(); // No need to create a new one for each iteration.
    string[] x = new string[] { "", "", "" };
    while(true) // This should probably be based on some condition, rather than 'true'
    {
        // Get random ConsoleColor string
        string colorName = colorNames[rand.Next(numColors)];
        // Get ConsoleColor from string name
        ConsoleColor color = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorName);
        // Assuming you want to set the Foreground here, not the Background
        Console.ForegroundColor = color;
        Console.WriteLine((x[rand.Next(x.Length)]));
        Thread.Sleep(100);
    }
