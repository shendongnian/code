    string str = "9/23/2012";
    DateTime dt;
    if(DateTime.TryParseExact(str,
                              "M/d/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None, 
                              out dt))
    {
        //valid date
    }
    else
    {
        //Invalid date
    }
