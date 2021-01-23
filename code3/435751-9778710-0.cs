    // Group by combiner ID, date, and hour
    var groups = FirstQ.ToList()
        .GroupBy(q => new 
            { q.Combiner, Date = q.RecordTime.Date, Hour = q.RecordTime.Hour });
    foreach (var group in groups)
    {
        var combinerId = group.Key.Combiner;
        var interval = new DateTime(group.Key.Date.Year, group.Key.Date.Month, group.Key.Date.Day, group.Key.Hour, 0, 0);
        // power = voltage * current? I think...
        var kwh = group.Sum(g => g.Voltage * g.Current) / 1000;
    }
