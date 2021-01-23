    var groups = _uow.Orders.GetAll()
                .Where(x => x.Created > baselineDate)
                .GroupBy(x => x.Created.Day);
    			
    var orders = new {
    	Day = groups.Select(g => g.Key).ToArray(),
    	Total = groups.Select(g => g.Sum(t => t.Toal)).ToArray()
    };
