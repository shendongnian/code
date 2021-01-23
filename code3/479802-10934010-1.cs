    var actions = (from a in entities.Actions 
                    group a by a.Date.ToShortDateString()
                    into g 
                    select new 
                    {
                        // Since count is useless on its own, store the date as well.
                        Date = g.First().Date.ToShortDateString(),
                        Actions = g.Count()
                    });
