    var query2 = (from a in this.db.Servers
                 join b in this.db.Components
                 on a.ServerID equals b.ServerID                        
                 select new { a.ServerID, b.Name })
                 .AsEnumerable()
                 .GroupBy(a => a.ServerID)
                 .SelectMany(g => (new [] {g.Key}).Concat(g.Select(i=>i.Name)));
    string[] header = query2.ToArray();
