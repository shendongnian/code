    Console.Write("Please Input the Starting Node : \n");
    starting_position = Convert.ToInt32(Console.ReadLine());
    while (starting_position < 0 || starting_position >= trace.Count)
    {
        Console.Write("Starting Node is invalid. Should be between 0 and 220. Please enter another one  : \n");
        starting_position = Convert.ToInt32(Console.ReadLine());
    }
