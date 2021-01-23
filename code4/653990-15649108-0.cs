    var limitedQuery = from g in refGroupQuery
                       select new
                       {
                           Reference = g.Key,
                           RecentMeasurements = g.OrderByDescending( p => p.CreationTime ).Take( numOfEntries )
                       }
