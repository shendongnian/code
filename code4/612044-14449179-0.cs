    private mostRecentDate= DateTime.MinValue;
    foreach (var date in myDates)
    {
        if (date > mostRecentDate)
        {
            mostRecentDate= date;
        }
    }
    // Do something with the most recent date in myDates...
