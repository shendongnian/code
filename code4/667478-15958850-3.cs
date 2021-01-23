    double parsed = 0;
    try 
    {
        parsed = Convert.ToDouble(fields[i]);
    }
    catch (FormatException e) 
    { 
        Console.WriteLine("Couldn't parse '{0}'", fields[i]);
        continue;
    }
    x[i] = parsed;
    Console.WriteLine(parsed);
