    double parsed = 0;
    try 
    {
        parsed = Convert.ToDouble(fields[i]);
    }
    catch (FormatException e) 
    { 
        Console.WriteLine("Couldn't parse '" + fields[i].toString() + "'");
        continue;
    }
    Console.WriteLine(parsed);
