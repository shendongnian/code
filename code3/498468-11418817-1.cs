    Console.Write("Please give the value no "+ index + " :");
    while (false == int.TryParse(Console.ReadLine(), out num))
    { 
        //Errormessage if the user did not input an integer.
        Console.WriteLine("Your input is not valid, please try again.");
        Console.WriteLine();
        sum = 0;
    }
    //Calculate the numbers given by user
    sum += num;
