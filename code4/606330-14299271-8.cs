	var custItems =  new [] {
		new { customer = 1, item = 1 },
		new { customer = 1, item = 2 },
		new { customer = 1, item = 3 },
		new { customer = 2, item = 4 },
		new { customer = 2, item = 2 },
		new { customer = 3, item = 5 },
		new { customer = 3, item = 1 },
		new { customer = 3, item = 2 },
		new { customer = 4, item = 1 },
		new { customer = 4, item = 2 },
		new { customer = 5, item = 5 },
		new { customer = 5, item = 1 }
	};
	};
    
    var pairs = custItems.GroupBy(x => x.customer)
             .Where(g => g.Count() > 1)
    	     .Select(x =>  (from a in x.Select( y => y.item )
                            from b in x.Select( y => y.item )
                            where a < b //If you want to avoid duplicate (a,b)+(b,a)
                            // or just: where a != b, if you want to keep the dupes.
                            select new { a, b}))
             .SelectMany(x => x)
             .GroupBy(x => x)
             .Select(g => new { Pair = g.Key, Count = g.Count() })
             .ToList();
    pairs.ForEach(x => Console.WriteLine(x));
