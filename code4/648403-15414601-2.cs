    public IEnumerable<NonWorkingDay> GetContiguousDates(IEnumerable<DateTime> dates)
    {
        return dates.OrderBy(d => d)
                .GroupWhile((previous, next) => GetNextWorkDay(previous).Date == next.Date)
                .Select(group =>
                {
                    var list = group.ToList();
                    return new NonWorkingDay
                    {
                        Start = list.First(),
                        Days = list.Count(),
                    };
                });
    }
