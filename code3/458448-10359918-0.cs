    private List<Holding> CombineHoldings(
        List<Holding> holdingsToAdd, 
        List<Holding> existingHoldings) 
    {
        var holdings = existingHoldings.Concat(holdingsToAdd)
            .GroupBy(h => h.Sector)
            .Select(g => 
            { 
                var result = g.First(); 
                result.Percentage = g.Select(h => h.Percentage).Sum();
                return result; 
            });
        return holdings.ToList();
    }
