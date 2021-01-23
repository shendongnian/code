    var query = (from c in db.Clients
                let TotalMales = (
                from c2 in db.Clients.Where(a=>a.Sex=='male') where c.Country=c2.Country select c2).Count()
                group c by new {c.Country, TotalMales}
                into g
                select new {
                    g.Key.Country,
                    TotalClients = g.Count(),
                    TotalMales = g.Key.TotalMales,
                    TotalFemales = g.Count()-TotalMales
                }).OrderBy(s=>s.Country);
