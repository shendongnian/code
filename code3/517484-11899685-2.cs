    while (true)
    {    
        Console.WriteLine("Enter the value of a:"); 
        if (Int32.TryParse(Console.ReadLine(), out a))
        {
            break;
        }
    }
