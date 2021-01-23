        DateTime lastMonth = startdate;
        var unionresults = result.SelectMany(r =>
        {
            var actualDate = new DateTime(r.Year, r.Month, 1);
            var results = Enumerable.Repeat(1, Months)
                .Select(i => lastMonth.AddMonths(i))
                .TakeWhile(date => date < actualDate)
                .Select(date => new { Year = date.Year, Month = date.Month, Count = 0 })
                .Concat(new[] { r });
            lastMonth = actualDate;
            return results;
        });
