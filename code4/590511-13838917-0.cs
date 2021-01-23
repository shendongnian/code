    var data = new[] {
     new { Id = 0, Cat = 1, Price = 2 },
     new { Id = 1, Cat = 1, Price = 10 },
     new { Id = 2, Cat = 1, Price = 30 },
     new { Id = 3, Cat = 2, Price = 50 },
     new { Id = 4, Cat = 2, Price = 120 },
     new { Id = 5, Cat = 2, Price = 200 },
     new { Id = 6, Cat = 2, Price = 1024 },
    };
    
    var ranges = new[] { 10, 50, 100, 500 };
    
    var result = from r in ranges
    		from g in data
    		where g.Price >= r
    		select new {g.Cat, Price=r};
    
    var groupedData = 
    		from d in result
    		group d by new{d.Cat, d.Price} into g
    		select new{Cat=g.Key.Cat, Price=g.Key.Price, TotalCount=g.Count()};
