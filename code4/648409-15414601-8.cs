    public IEnumerable<NonWorkingDay> GetContiguousDates(IEnumerable<DateTime> dates)
    {
        return dates.OrderBy(d => d)
                .GroupWhile((previous, next) => GetNextWorkDay(previous).Date == next.Date)
                .Select(group => new NonWorkingDay
                    {
                        Start = group.First(),
                        Days = group.Count(),
                    });
    }
