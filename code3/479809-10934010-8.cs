    var actions = (from a in entities.Actions 
                    // Note: if a.Date was a DateTime object, you could simply
                    // group by 'a.Date.Date'
                    group a by DateTime.Parse(a.Date).Date
                    into g 
                    select new 
                    {
                        // Since count is useless on its own, store the date as well.
                        Date = g.Key,
                        Actions = g.Count()
                    });
