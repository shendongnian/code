    Console.WriteLine("Your age:");
    string line = Console.ReadLine();
    while (!int.TryParse(line, out age))
    {
        Console.WriteLine("{0} is not an integer", line);
        string line = Console.ReadLine();
    }
