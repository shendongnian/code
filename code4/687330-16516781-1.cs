    DateTime dt;
    if (DateTime.TryParseExact("5/13/2013 12:21:35 PM",
                                      "M/d/yyyy hh:mm:ss tt",
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None,
                                      out dt))
    {
        //date is fine
    }
