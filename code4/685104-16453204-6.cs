    public DateTime GetNextAnniversary(DateTime startDate)
    {
        var now = DateTime.Now
        var next = new DateTime(now.Year, startDate.Month, startDate.Day);
        return now > next ? next.AddYears(1) : next;
    }
