    var weekGroups = projects
        .Select(p => new 
        { 
            Project = p, 
            Year = p.DateStart.Year, 
            Week =  CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                          (p.DateStart, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        })
        .GroupBy(x => new { x.Year, x.Week })
        .Select((g, i) => new 
        { 
            WeekGroup = g, 
            WeekNum = i + 1,
            Year = g.Key.Year,
            CalendarWeek = g.Key.Week
        });
    foreach (var projGroup in weekGroups)
    {
        Console.WriteLine("Week " + projGroup.WeekNum);
        foreach(var proj in projGroup.WeekGroup)
            Console.WriteLine("{0} {1} {2}", 
                proj.Project.Name, 
                proj.Project.DateStart.ToString("d"), 
                proj.Project.ID);
    }
