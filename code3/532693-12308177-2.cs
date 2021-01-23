    int amount;
    while(true)
    {
        Console.WriteLine("How many students would you like to enter?"); 
        string number = Console.ReadLine(); 
        if(Int32.TryParse(number, out amount))
            break;
    }
    Console.WriteLine("{0} {1}", "amount equals", amount); 
    for (int i=0; i < amount; i++) 
    { 
        Console.WriteLine("Input the name of a student"); 
        String StudentName = Console.ReadLine(); 
        Console.WriteLine("the Students name is " + StudentName); 
    } 
