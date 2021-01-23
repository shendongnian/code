    string hold1=NumGen.CardGenerator(i);
    try
    {
        if (File.Exists(hold1))
            Console.WriteLine("The file {0} was found.", hold1);
        else
            Console.WriteLine("Error: The file {0} cannot be found", hold1);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("I don't understand the path you supplied.");
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.ToString());
    }
