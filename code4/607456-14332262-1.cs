    DateTime start = new DateTime(1900, 1, 1);
    DateTime end = new DateTime(2000, 12, 31);
    DateTime date = ... use the previous method to parse your string
    if (date > start && date < end)
    {
        // success
    }
    else
    {
        // the date is outside the range
    }
