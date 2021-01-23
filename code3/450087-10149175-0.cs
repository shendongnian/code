    List<DateTime> split =
      splitDates.Where(d => d >= dateFrom && d <= dateTo).ToList();
    List<Tuple<DateTime, DateTime>> periods =
      Enumerable.Range(0, split.Count + 1)
      .Select(i => new Tuple<DateTime, DateTime>(
        i == 0 ? dateFrom : split[i - 1].AddDays(1),
        i == split.Count ? dateTo : split[i]
      ))
      .ToList();
