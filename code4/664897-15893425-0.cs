    DateTime myDate;
    if (DateTime.TryParseExact(inputString, "dd-MM-yyyy hh:mm:ss", 
        CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate))
    {
        //String has Date and Time
    }
    else
    {
        //String has only Date Portion    
    }
