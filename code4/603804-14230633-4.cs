    Dictionary<DateTime, int> dateGroups = table.AsEnumerable()
    .GroupBy(r => r.Field<DateTime>("Date").Date)
    .Select(g => new
    {
        Date = g.Key,
        TotalHours = 
            g.Max(r => DateTime.Parse(r.Field<string>("SwipeTime")).TimeOfDay.Hours)
          - g.Min(r => DateTime.Parse(r.Field<string>("SwipeTime")).TimeOfDay.Hours)
    }).ToDictionary(x => x.Date, x => x.TotalHours);
