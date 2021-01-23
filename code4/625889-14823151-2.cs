    DateTime Origin = new DateTime(1970, 1, 1, 12, 0, 0, 0);
    DateTime Start = DateTime.Parse("01/01/1970 12:00:00");
    DateTime End = DateTime.Parse("01/01/1970 12:00:00");
    DateTime Start1 = DateTime.Parse("02/10/2013 12:20:00");
    DateTime End1 = DateTime.Parse("02/10/2013 14:20:00");
    TimeSpan Break, Break1;
    if (Origin.Year != Start.Year)
    {
        Break = End.Subtract(Start);
    }
    else
    {
        Break = TimeSpan.Zero;
    }
    if (Origin.Year != Start1.Year)
    {
        Break1 = End1.Subtract(Start1);//break1 value must be 2hrs
    }
    else
    {
        Break1 = TimeSpan.Zero;
    }
    TimeSpan FinalBreakResult = Break + Break1;
    // Value of FinalBreakResult is 2 hours
