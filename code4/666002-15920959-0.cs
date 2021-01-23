    DateTime result;
    if (DateTime.TryParseExact(text, "hh:mmtt", CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out result))
    {
        Console.WriteLine("Parsed to: {0}", result);
    }
