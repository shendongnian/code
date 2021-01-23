    string input = "2012-02-25 07:53:04";
    
    DateTime dateTime;
    if (!DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm:ss",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out dateTime))
    {
        Console.WriteLine("Couldn't parse value");
    }
    else
    {
        string formatted = dateTime.ToString("dd-MM-yyyy HH:mm:ss",
                                             CultureInfo.InvariantCulture);
        Console.WriteLine("Formatted to: {0}", formatted);
    }
