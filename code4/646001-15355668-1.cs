        DateTime startdate = DateTime.Parse("somedate");
        DateTime enddate = DateTime.Parse("somedate");
        int daycount = 0;
        while (startdate < enddate)
        {
            startdate = startdate.AddDays(1); // Fixed
            int DayNumInWeek = (int)startdate.DayOfWeek;
            if (DayNumInWeek != 0)
            {
                if (DayNumInWeek != 6)
                { daycount += 1; }
            }
        }
