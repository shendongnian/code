    var date = new DateTime(2011, 12, 19);
    var end = new DateTime(2012, 4, 26); // five weeks from now
    while (date < end)
    {
        if (date > DateTime.Now)
        {
            // This is a date you want
        }
        date = date.AddDays(14);
    }
