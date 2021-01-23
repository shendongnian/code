    if (myScen.EndsWith("."))
    {
        Console.WriteLine("\n\tScentence Ended Correctly");
        // Calculate number of characters
        foreach (char c in myScen)
        {
            numbChar++;
            if (c == ' ')
                continue;
            newScen += c;
        }
        Console.WriteLine("\n\tThere are {0} characters. \n\n\n",numbChar);
    }
    else
        Console.WriteLine("Invalid Scentence");
