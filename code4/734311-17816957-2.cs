    Console.WriteLine ("Please enter some numbers");
    int sum = 0;
    
    while (true)
    {
        int parsedInput = 0;
        string input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out parsedInput))
        {
            sum += parsedInput;
            Console.WriteLine (sum);
        }
        else
        break;
    }
