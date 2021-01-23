    var res = list
        .GroupBy(v => v.ID)
        .ToDictionary(
            g => g.Key
        ,   g => g.GroupBy(v => v.START_DATE.Date)
            .ToDictionary(h => h.Key, h => h.Seelct(x => x.ID_OWNER).Distinct().Count())
        );
