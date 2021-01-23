    DateTime myDate;
    DateTime.TryParse(inputString, out myDate);
    if (myDate == DateTime.MinValue)
    {
        //Date string is not well-formed
    }
    if (myDate.Hour == 0 && myDate.Minute == 0 && myDate.Second == 0)
    {
        //Only Date was passed, without passing time
    }
