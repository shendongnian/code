    Console.WriteLine("Your age:");
    string line = Console.ReadLine();
    try
    {
        age = Int32.Parse(line);
    }
    catch (FormatException)
    {
        Console.WriteLine("{0} is not an integer", line);
        // Return? Loop round? Whatever.
    }
