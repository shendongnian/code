    while (input.ToUpper() != "END")
    {
        bool blnAdd = true;
        if (dictionaryList.Contains(input))
        {
            Console.Write("Already exists, keep the duplicate? (Y/N)");
            blnAdd = Console.ReadLine().Equals("Y");
        }
    
        if (blnAdd)
            dictionaryList.Add(input);
    
        Console.Write("Please enter a string or END to finish: ");
        input = Console.ReadLine();
    }
