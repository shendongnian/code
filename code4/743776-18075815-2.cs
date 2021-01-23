    int[] userInputs = new int[100];
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
            userInputs[i] = parsedInput;
            inputs++;
        }
        else
        {
            Console.WriteLine("Please enter a number only!");
        } 
    }
    for each (int number in userInputs)
    {
        Console.WrietLine(number.ToString());
    }
