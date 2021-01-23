    string firstName = TryGetValue(arguments,"firstname");
    string lastName= TryGetValue(arguments,"lastName");
    string amount = TryGetValue(arguments,"amount");
    
    bool isValid = firstName!=null && lastName != null && amount != null;
    
    if(isValid)
    {
        Console.WriteLine(firstName ); // Displays foo
        Console.WriteLine(lastName); // Displays bar
        Console.WriteLine(amout); // Displays 100.58
    }
