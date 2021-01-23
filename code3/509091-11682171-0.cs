    // Setting end date to start date plus 5 days
    var start = new DateTime(); 
    var end = start.AddDays(5)
    
    // Testing if end date is the same as start date plus 5 days
    if (start.AddDays(5) == end)
    {
        // It true!
    }
    /// or like so...
    if (end.subtract(start).Days >= 5)
    {
        // It true!
    }
