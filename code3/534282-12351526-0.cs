    var grouped = 
        from a in actions
        group a by new { a.ActionID, a.ActionType } 
        into g
        select new 
        { 
            ActionID   = g.Key.ActionID, 
            ActionType = g.Key.ActionType, 
            Values     = 
                (from x in g
                 select new KeyValuePair<string, string>(x.ActionDetail, x.Value))
                .ToDictionary()
        };
