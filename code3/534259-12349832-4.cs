    protected string GetCustomDateFormat(object dateTimeObj)
    {
        DateTime dateTime = (DateTime)dateTimeObj;
        if (dateTime.Date == DateTime.Today)
        {
            return dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            //This Gives the Time in the Format (ex: 8:30 PM)
            //return dateTime.ToShortTimeString();
            // or you can specify format: dateTime.ToString("t")
        }
        else
        {
            return dateTime.ToShortDateString();
            // or you can specify format: dateTime.ToString("m")
        }
    }
