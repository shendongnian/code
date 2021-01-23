    Console.WriteLine("Please enter a number:");
    int value = Convert.ToInt32(ConsoleReadLine());
    while (value > 50 || value < 10)
    {
        Console.WriteLine("Please enter numbers only between 10 and 50.");
        value = Convert.ToInt32(Console.ReadLine());
    }
    // Now we know it's valid, so it's reasonably to put it in the array
    mArray[i] = value;
