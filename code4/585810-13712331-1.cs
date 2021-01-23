    DateTime now = DateTime.UtcNow;
    DateTime lowerBound = new DateTime(now.Year, now.Month, now.Hour, now.Minute,
                                       0, 0, DateTimeKind.Utc);
    DateTime upperBound = now.AddMinutes(1);
    if (entity.End >= lowerBound && entity.End < upperBound)
    {
        ...
    }
