    public static List<Holding> MissingHoldings(List<Holding> existingHoldings, DateTime startDate, DateTime endDate)
    {
        var missingHoldings = new List<Holding>();
        var holdingIds = existingHoldings.Select(h => h.HoldingId).Distinct().ToList();
        var dates = new List<DateTime>();
        for (var current = startDate.Date; current <= endDate.Date; current = current.AddDays(1))
        {
            dates.Add(current);
        }
        foreach (var holdingId in holdingIds)
        {
            missingHoldings
                .AddRange(
                    dates.Where(date => !existingHoldings.Any(h => h.HoldingId == holdingId && h.date == date))
                    .Select(date => new Holding {HoldingId = holdingId, date = date}));
        }
        return missingHoldings;
    }
