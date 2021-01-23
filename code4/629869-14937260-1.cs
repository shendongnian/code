    var abRotations = datesList
        .GroupBy(d => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
        .Select((wg, i) => new { WeekGroup = wg, Index = i })
        .GroupBy(x => x.Index % 2);
    List<DateTime> A_Rotation = abRotations.First().SelectMany(x => x.WeekGroup).ToList();
    List<DateTime> B_Rotation = abRotations.Last().SelectMany(x => x.WeekGroup).ToList();
