    var actions = (from a in entities.Actions 
                    group a by a.Date.Date
                    into g 
                    select new 
                    {
                        // You'll want to know which dates the map to
                        // which count calues, so get the date here too.
                        Date = g.Key,
                        Actions = g.Count()
                    });
