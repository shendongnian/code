    DateTime date1 = new DateTime(2013, 8, 1, 0, 0, 0);
    DateTime date2 = new DateTime(2013, 8, 1, 12, 0, 0);
    int result = DateTime.Compare(date1, date2);
    if (result < 0)
    {
        // date1 is earlier than date2;
    }
    else if (result == 0)
    {
        // date1 is the same time as date2
    }
    else
    {
        // date1 is later than date2
    }
