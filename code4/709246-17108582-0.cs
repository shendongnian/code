    var res = list
        .GroupBy(v => v.ID)
        .ToDictionary(g => g.Key
        ,   g.GroupBy(v => v.START_DATE.Date)
            .ToDictionary(h => h.Key, h => h.Count())
        );
