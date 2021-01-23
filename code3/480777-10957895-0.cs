    // Store this as a static variable, it will never be changing
    String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
    
    // ...
    Random rand = new Random(); // No need to create a new one for each iteration.
    string[] x = new string[] { "", "", "" };
    while(true) // This should probably be based on some condition, rather than 'true'
    {
        // Get random ConsoleColor string
        string randomColorName = colorNames[rand.Next(colorNames.Length)];
        // Get ConsoleColor from string name
        ConsoleColor color = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorName);
    
        Console.WriteLine((x[rand.Next(3)]));
        Thread.Sleep(100);
    }
