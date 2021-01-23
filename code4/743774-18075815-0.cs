    int[] userInput = new int[100];
    int parsedInput;
    int inputs = 0;
    bool stop = false;
    while (inputs < 100 && !stop)
    {
        string userInput = Console.ReadLine();
        if (userInput == "")
        {
            stop = true;
        }
        else if (Int32.TryParse(userInput, out parsedInput))
        {
            input[i] = parsedInput;
            inputs++;
        }
        else
        {
            Console.WriteLine("Please enter a number only!");
        } 
    }
    for each (int number in input)
    {
        Console.WrietLine(number.ToString());
    }
