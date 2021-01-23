        var subQuery = from c in scope.Entities.Clicks
                       where c.Created >= startDate && c.Created <= endDate
                       select new { c.Created.Year, c.Created.Month, c.Created.Day };
        var query = from c in subQuery
                    group c by new {c.Year, c.Month, c.Day}
                    into grouped
                    select new {
                                 Year = grouped.Key.Year,
                                 Month = grouped.Key.Month,
                                 Day = grouped.Key.Day,
                                 Clicks = grouped.Count()
                               };
