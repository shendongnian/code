    if (span.TotalSeconds >= 60 * 60)
    {
        Console.WriteLine("hours");
    }
    else if (span.TotalSeconds >= 60)
    {
        Console.WriteLine("minutes");
    }
    else
    {
        Console.WriteLine("seconds");
    }
