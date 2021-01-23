    var quarters = RMAs
        .Where(rma => rma.CreatedDate.Year > DateTime.Now.Year - 4)
        .GroupBy(rma => new { 
            Year = rma.CreatedDate.Year, 
            Quarter = ((rma.CreatedDate.Month) / 3) 
        });
    
    return Json.Encode(
        RMAs
            //Only grab the last 4 years worth of RMAs
            .Where(r => r.CreatedDate.Year > DateTime.Now.Year - 4)
            // Group all records by problem     
            .GroupBy(r => new { Problem = r.Problem })
            .Select(grouping => new
                {
                    Problem = grouping.Key.Problem,
                    Occurrences = quarters.Select(quarter => new
                        {
                            Year = quarter.Key.Year,
                            Quarter = quarter.Key.Quarter,
                            Count = grouping
                                    .GroupBy(record => new
                                    {
                                        Year = record.CreatedDate.Year,
                                        Quarter = ((record.CreatedDate.Month) / 3)
                                    })
                                    .Where(record => 
                                        record.Key.Year == quarter.Key.Year 
                                        && record.Key.Quarter == quarter.Key.Quarter
                                    ).Count()
                        }).ToArray()
                }));
