    public static DateTime ChangeTime(DateTime dateTime)
    {
        return new DateTime(
        	dateTime.Year,
        	dateTime.Month,
        	dateTime.Day,
        	DateTime.Now.Hour,
        	DateTime.Now.Minute,
        	DateTime.Now.Second,
        	DateTime.Now.Millisecond,
        	DateTime.Now.Kind);
    }
