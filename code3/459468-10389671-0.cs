    // generates a dictionary of fare codes and total quantity of orders per fare code
    var fareQuantities = Orders.GroupBy(o => o.FareCode).ToDictionary(og => og.Key, og => og.Sum(o => o.Quantity));
    
    using(var dc = new datacontext())
    {
        var query = dc.Fares
            .Where(f => fareQuantities.Keys.Contains(f.FareCode))
            .ToDictionary(f => f, f => fareQuantities[f.FareCode]);
        // query is now a dictionary of fares and the total quantities of each fare ordered
    }
