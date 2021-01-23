    // we'll just use the existing settings on the box.
    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    var cal = dfi.Calendar;
    var Projects = GetProjectsFromSomewhere(); // assuming IEnumerable<Project>
    int week = 1; // this *could* be changed and projected in the Select instead.
    foreach (var wg in from p in Projects
        group p by cal.GetWeekOfYear(
            p.StartDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))
    {
        Console.WriteLine("Week {0}", week);
        foreach (var p in wg)
        {
            Console.WriteLine("    {0} {1} {2}", p.Name, p.StartDate, p.ID);
        }
        week++;
    }
