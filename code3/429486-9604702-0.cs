    DateTime value;
    if (DateTime.TryParseExact(text, "M/d/yyyy H:mm:ss",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out value))
    {
        Console.WriteLine("Parsed to {0}", value);
    }
    else
    {
        Console.WriteLine("Failed to parse");
    }
