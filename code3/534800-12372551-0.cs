    var result = from r in (
    
        from l in lines.Skip(1)
        let data = l.Split(new string[]{";"," "}, 
                           StringSplitOptions.RemoveEmptyEntries)
        select new { Id = data.First(), Item = data.Skip(1).First() })
        .Aggregate(new 
                    { 
                        Rows = Enumerable.Repeat(new 
                                                { 
                                                    Id = string.Empty, 
                                                    Items = new List<string>() 
                                                }, 1).ToList(), 
                        LastID = new List<string>() { "" } 
                    }, 
                    (acc, x) => 
                    { 
                        if (acc.Rows[0].Id == string.Empty)
                            acc.Rows.Clear();
                        if (acc.LastID[0] != x.Id)
                            acc.Rows.Add(new 
                                        {
                                            Id = x.Id, 
                                            Items = new List<string>() 
                                        });
                        acc.Rows.Last().Items.Add(x.Item);
                        acc.LastID[0] = x.Id;
                        return acc; 
                    }       
        ).Rows
    select new 
    { 
        r.Id, 
        Items = string.Join(";", from x in r.Items 
                                 select x) 
    };
