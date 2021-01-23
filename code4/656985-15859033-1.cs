    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        String[] argArray = e.Argument.Split(",".ToCharArray());
        if (argArray.Length > 2 && argArray[0] == "TimeSlotMenuItemClicked")
        {
            DateTime dtStart = GetDateTimeFromArgument(argArray[1]);
            DateTime dtEnd = GetDateTimeFromArgument(argArray[2]);
            // Starting date/time is the end of the first timeslot; adjust to arrive at the beginning
            TimeSpan tsSlotLength = new TimeSpan(0, RadScheduler1.MinutesPerRow, 0);
            dtStart -= tsSlotLength;
            // Do what we need to do with the start/end now
        }
    }    
    /// <summary>
    /// Date/Time format will look like this:  "Sat Apr 06 2013 10:30:00 GMT-0700 (US Mountain Standard Time)"
    /// Turn this from a string into a date.
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    private DateTime GetDateTimeFromArgument(string arg)
    {
        // Extract the timezone qualifier and put together a string we can parse.
        string formattedArg = string.Format("{0} {1}:{2}", 
            arg.Substring(0, 24), arg.Substring(28, 3), arg.Substring(31, 2));
        return DateTime.ParseExact(formattedArg,
            "ddd MMM dd yyyy HH:mm:ss zzz",
            CultureInfo.InvariantCulture);
    }
 
