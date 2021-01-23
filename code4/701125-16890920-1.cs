        string Input = Console.ReadLine();
        char[] Number = Util.SetNumber(Input);
        
        foreach (char digit in Number)
        {
            Console.WriteLine(digit);
        }
        Console.ReadKey(); 
