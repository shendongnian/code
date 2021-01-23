    var suburbGroups = customers
            .GroupBy(c => c.Suburb)
            .Select(g => new { Suburb = g.Key, Balance = g.Sum(c => c.Balance) })
            .OrderByDescending(x => x.Balance);
    foreach(var grp in suburbGroups)
        Console.WriteLine("Suburb: {0}  Total-Balance: {1}", grp.Suburb, grp.Balance);
