    //These values must be static and public so that they'd be accessible through the second form
    public static bool DateChanged = false;
    public static DateTime _fromDate;
    public static DateTime _toDate;
    private void SetValues()
    {
        _fromDate = dtFromDate.DateTime.ToUniversalTime();
        _toDate = dtToDate.DateTime.ToUniversalTime();
        DateChanged = true; //Set DateChanged to true to indicate that there has been a change made recently
    }
