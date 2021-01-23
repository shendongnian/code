    var dict = db.Customers
                 // Here i is a full Customer, logically...
                 .Select(i => new { i.Id1, i.Id2 })
                 // But here p is just the pair of Id1, Id2
                 .ToDictionary(p => p.Id1, p => p.Id2);
