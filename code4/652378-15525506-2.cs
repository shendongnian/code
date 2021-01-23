    DateTime result;
    if (DateTime.TryParse(date, out result))
    {
        Console.WriteLine(result.ToString("dd"));
        Console.WriteLine(result.ToString("MMMM"));
        Console.WriteLine(result.ToString("yyyy"));
    }
    else
    {
        Console.WriteLine("Error parsing date.");
    }
