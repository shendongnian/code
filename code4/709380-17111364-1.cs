    var query2 = (from a in this.db.Servers
                 join b in this.db.Components
                 on a.ServerID equals b.ServerID  into g
                 select new { 
                    a.ServerID, 
                    Components = g.Select(x => x.Name) 
                 })
                 .AsEnumerable()
                 .SelectMany(g => (new [] {g.ServerID}).Union(g.Components));
