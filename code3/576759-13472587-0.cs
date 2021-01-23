     var q =
        from t1 in
            table1.GroupBy(g => g.ID).Select(g => new
            {
                ID = g.Key,
                Message = string.Join("*", g.Select(v => v.Message).ToArray())
            })
        join
            t2 in
            table2.GroupBy(g => g.ID).Select(g => new
            {
                ID = g.Key,
                Message = string.Join("*", g.Select(v => v.Message).ToArray())
            }) on t1.ID equals t2.ID
        select new
        {
            ID = t1.ID,
            ErMessage = t1.Message,
            WrMessage = t2.Message
        };
