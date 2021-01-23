    var names = db.People
       .Where(r => r.Name.Contains(q))
       .GroupBy(r => new { Name = r.Name, Surname = r.Surname })
       .Select(g => g.First())
       .Take(5);
