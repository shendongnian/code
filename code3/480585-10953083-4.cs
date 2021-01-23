    return Json.Encode(
        RMAs
            //Only grab the last 4 years worth of RMAs
            .Where(r => r.CreatedDate.Year > DateTime.Now.Year - 4)
            // Group all records by problem     
            .GroupBy(r => new { Problem = r.Problem })
            .Select(grouping =>
            new
            {
                // Get the Problem of this grouping
                Problem = grouping.Key.Problem,
                // Get all occurrences of this Problem in this grouping
                Occurrences = grouping
                    // Group all records by Year/Quarter
                    .GroupBy(record => new
                    {
                        Year = record.CreatedDate.Year,
                        Quarter = ((record.CreatedDate.Month) / 3)
                    })
                    // Get the Year, the Quarter, and Count
                    .Select(record => new
                    {
                        Year = record.Key.Year,
                        Quarter = record.Key.Quarter,
                        Count = record.Count()
                    }).ToArray()
            }));
