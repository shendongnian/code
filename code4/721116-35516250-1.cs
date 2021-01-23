    private static void Main(string[] args)
    {
        Random random = new Random();
    
        var query =
            typeof(ConsoleColor)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fieldInfo => (ConsoleColor)fieldInfo.GetValue(null))
                .ToArray();
    
        Console.BackgroundColor = query.ElementAt(random.Next(query.Length));
    
        Console.WriteLine(Console.BackgroundColor);
    
        Console.Read();
    }
