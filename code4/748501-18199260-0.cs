    char c;
    while ((c = Console.ReadKey(true).KeyChar) != '!')
    {
        if (char.IsLower(c))
        {
            Console.WriteLine("OK");
            continue;
        }
        Console.WriteLine("The character is not a lowercase letter.");
    }
