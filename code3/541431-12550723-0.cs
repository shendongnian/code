    int age;
    Console.WriteLine("Your age:");
    string line = Console.ReadLine();
    while (!int.TryParse(line, out age))
    {
        Console.WriteLine("{0} is not an integer", line);
        Console.WriteLine("Your age:");
        line = Console.ReadLine();
    }
