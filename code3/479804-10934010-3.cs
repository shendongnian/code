    var actions = (from a in entities.Actions 
                    group a by a.Date.Date
                    into g 
                    select new 
                    {
                        // Since count is useless on its own, store the date as well.
                        Date = g.First().Date.Date,
                        Actions = g.Count()
                    });
