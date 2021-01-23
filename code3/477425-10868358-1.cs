    if ("anytest#".ToCharArray().All(c => char.IsLetterOrDigit(c) || c == '_'))
    {
        Console.WriteLine("Success");
    }
    else
    {
        Console.WriteLine("Error");
    }
