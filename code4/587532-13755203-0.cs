    DateTime dt;
    DateTime utcDate;
    if (DateTime.TryParse(dateTimeString, out dt))
    {
        utcDate = dt.ToUniversalTime();
        // store utcDate in database
    }
    else
    {
        // error, unable to parse the date
    }
