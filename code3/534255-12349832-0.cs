    protected string GetCustomDateFormat(object dateTimeObj)
    {
        DateTime dateTime = (DateTime)dateTimeObj;
        if (dateTime.Date == DateTime.Today)
        {
            return dateTime.ToShortTimeString();
            // or you can specify format: dateTime.ToString("t")
        }
        else
        {
            return dateTime.ToShortDateString();
            // or you can specify format: dateTime.ToString("m")
        }
    }
