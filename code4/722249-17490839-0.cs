    Console.Write("Green = ");
    input = Console.ReadLine();
    if (!Double.TryParse(input, out green))
    {
        Console.WriteLine("You have not entered an appropriate value!");
    }
