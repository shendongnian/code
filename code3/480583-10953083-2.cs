    var query = RMAs
            //Only grab the last 4 years worth of RMAs
            .Where(r => r.CreatedDate.Year > DateTime.Now.Year - 4);
    
    return Json.Encode(
        query
        .GroupBy(r => new
        {
            Problem = r.Problem,
            Year = r.CreatedDate.Year,
            Quarter = ((r.CreatedDate.Month) / 3)
        })
        .Select(r =>
            new
            {
                Problem = r.Key.Problem,
                Occurrences = query
                    // Only get occurrences where Problem, Year, and Quarter match
                    .Where(entry => entry.Problem == r.Key.Problem
                        && entry.CreatedDate.Year == r.Key.Year
                        && ((entry.CreatedDate.Month) / 3) == r.Key.Quarter)
                    // ... get all such occurrences
                    .Select(entry =>
                    new
                    {
                        Year = r.Key.Year,
                        Quarter = r.Key.Quarter,
                        Count = r.Count()
                     // ... and store them to an array
                    }).ToArray()
            }));
