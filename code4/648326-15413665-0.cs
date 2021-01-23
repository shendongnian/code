    var notYearly = lockDates.Where(d => !d.IsYearly && (d.Date.Date >= start && d.Date.Date <= end)).Select(d => d.Date);
    var years = ((end - start).Days / 365) + 2;
    var startYear = start.Year;
    var yearly = lockDates.Where(d => d.IsYearly)
                            .SelectMany(d => Enumerable.Range(startYear, years)
                                                        .Select(e => new DateTime(e, d.Date.Month, d.Date.Day))
                                                        .Where(i => i.Date >= start && i.Date <= end));
    var allDates = notYearly.Union(yearly)
