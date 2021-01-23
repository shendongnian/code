    var result = responses
        .SelectMany(r => r.BoDPoints)
        .GroupBy(p => p.Date)
        .Select(byDate => 
            new 
            {
                Date = byDate.Key,
                EntriesByTime = byDate
                    .GroupBy(p => p.Time)
                    .Select(byTime => 
                        new 
                        {
                            Time = byTime.Key,
                            TotalVolume = byTime.Sum(p => p.Volume)
                        })
            });
