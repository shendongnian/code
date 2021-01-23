        var events = new List<DateTime>
        {
            new DateTime(2013,11,1),
            new DateTime(2013,5,1),
            new DateTime(2013,4,1),
            new DateTime(2012,12,29),
            new DateTime(2012,12,28)
        };
        var ev = events.Select(d => new { Month = d.Month, Date = d })
            .Where(d => (d.Date >= DateTime.Now || (d.Date.Day == DateTime.Now.Day && d.Date.Month >= DateTime.Now.Month)))
            .OrderBy(d => d.Date.Year)
            .Select(d => new { Month = d.Month })
            .Distinct();
