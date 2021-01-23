    // This is an example of a UNIX timestamp for the date/time
    double timestamp = 1116641532;
    
    // First make a System.DateTime equivalent to the UNIX Epoch.
    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
    
    // Add the number of seconds in UNIX timestamp to be converted.
    dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
