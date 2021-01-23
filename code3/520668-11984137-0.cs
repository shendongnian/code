    Console.Write("Response Value > ");
    if(float.TryParse(Console.ReadLine(), out Response)
    {
        Ask_Count = Ask_Count + 1;
        if (Response > 0 && Response < 6)
            Valid_Count = Valid_Count + 1;
    }
    else
        Console.WriteLine("Number entered is not a float");
