    public static void DateTimeTo30HourDay(DateTime tx_datetime)
    {
        if (tx_datetime.Hour < 6)
        {
            // subtract one day
            tx_datetime = tx_datetime.AddDays(-1);
        }
        int offsetHours = tx_datetime.Hour + 6;
        string tx_date = string.Format("{0}{1}{2}", tx_datetime.Year.ToString().PadLeft(4, '0'), tx_datetime.Month.ToString().PadLeft(2, '0'), tx_datetime.Day.ToString().PadLeft(2, '0'));
        string start_time = string.Format("{0}:{1}", offsetHours.ToString().PadLeft(2, '0'), tx_datetime.Second.ToString().PadLeft(2, '0'));
        // do what you want here
    }
