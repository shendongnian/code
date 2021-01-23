    while(myChoice > myNum.Length)
    {
        Console.Write("Please choose a number less than or equal to {0}: ", myNum.Length);
        myChoice = Int32.Parse(Console.ReadLine());
    }
