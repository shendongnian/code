    IEnumerable<DateTime> days;
    if (DateTime.Today.Day > 28 && DateTime.Today.Day < 2)
    {
        days = GetDaysLikeMe(calendario.Value.Date).Take(50).Where(d => d.Date.Day > 28 && d.Date.Day < 2).Take(4);
    }
    else
    {
        days = GetDaysLikeMe(calendario.Value.Date).Take(50).Where(d => d.Date.Day < 28 && d.Date.Day > 2).Take(4);
    }
