    private static IEnumerable<appointments> GetAppointmentsByWeek(List<appointments> appts, int weeknum)
    {
        var WeekGroup = appts.GroupBy(ap => GetWeekOfYear(ap.Start)).Where(gp => gp.Key == weeknum).FirstOrDefault();
        if (WeekGroup == null) {return new List<appointments>();} //No appointments for this week
        return WeekGroup.Select(gp => gp.ToList());
    }
