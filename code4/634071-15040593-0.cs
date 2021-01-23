    Console.WriteLine("Please enter the input");
    string input1 = Console.ReadLine();
    int number;
    bool valid = int.TryParse(out number);
    if (! valid)
    {
        Console.WriteLine("Entered value is not a number");
    }
    else
    {
        if (number == 4)
        {
            Console.WriteLine("You are a winnere");
        }
        else if (number > 4)
        {
            Console.WriteLine("TOOOOO high");
        }
        else if (number < 4)
        {
            Console.WriteLine("TOOOO Low");
        }
    }
    Console.ReadLine();
