    if (args == null || args.Length < 2)
    {
        //the arguments are not passed correctly, or not at all
    }
    else
    {
        try
        {
            yourFirstVariable = args[0];
            yourSecondVariable = args[1];
        }
        catch(Exception e)
        {
            Console.WriteLine("Something went wrong with setting the variables.")
            Console.WriteLine(e.Message);
        }
    }
