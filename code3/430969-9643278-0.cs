    string datestring = "2120121";
    
    DateTime td;
    if (DateTime.TryParseExact(datestring, "ddyyyyM", new CultureInfo("en-US"), DateTimeStyles.None, out td))
    {
        Console.WriteLine(td.ToShortDateString());
    }
    else
    {
        Console.WriteLine("Invalid Date String");
    }
