    for (int i = 0; i < 1001; i++)
    {
        if ((i % 2) == 0)
            Console.Write(i + " is even ");
        else
            Console.Write(i + " is odd ");
        if (i < 250)
            Console.WriteLine("and is less than 250");
        else if (i < 500)
            Console.WriteLine("and is greater than or equal to 250 and less than 500 ");
        else if (i < 750)
            Console.WriteLine("and is greater than or equal to 500 and less than 750 ");
        else
            Console.WriteLine("and is greater than or equal to 750 ");     
    }
    
    Console.ReadLine();
