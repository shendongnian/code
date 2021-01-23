    foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek))
                                  .OfType<DayOfWeek>()
                                  .ToList()
                                  .Skip(1)) {
        list.Add(day.ToString());
    }
    list.Add(DayOfWeek.Sunday.ToString());
