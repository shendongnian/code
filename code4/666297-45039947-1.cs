    var weekGroups = projects
        .Select(p => new 
        { 
            Project = p
        })
        .GroupBy(x => x.Project.DateStart.StartOfWeek(DayOfWeek.Monday))
        .Select((g, i) => new 
        { 
            WeekGroup = g, 
            WeekNum = i + 1
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
  
