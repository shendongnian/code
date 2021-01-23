    for (int i = 0; i < 1001; i++)
    {
        if ((i % 2) == 0)
            Console.WriteLine(i + " is even ");
        else
            Console.WriteLine(i + " is odd ");
        if (i < 250)
            Console.WriteLine(i + " is less than 250");
        else if (i < 500)
            Console.WriteLine(i + " is greater than or equal to 250 and less than 500 ");
        else if (i < 750)
            Console.WriteLine(i + " is greater than or equal to 500 and less than 750 ");
        else
            Console.WriteLine(i + " is greater than or equal to 750 ");     
    }
    
    Console.ReadLine();
