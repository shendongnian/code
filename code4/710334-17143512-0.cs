      db.Attendances
        .Select(a => new {
            a.name,
            hours = SqlFunctions.DateDiff("seconds", a.ClockInTime, a.ClockOutTime)
        })
        .GroupBy(x => x.name)
        .Select(g => new AttendanceViewModel {
            name = g.Key,
            totalHours = Sum(x => x.hours)
        })
       .ToList();
