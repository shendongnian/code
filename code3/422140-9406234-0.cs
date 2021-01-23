    public int? WinningRoll(IEnumerable<int> rolls)
    {
        int threshold = rolls.Count() / 2;
		
        var topRollGroup = rolls.GroupBy(r => r)
            .SingleOrDefault(rg => rg.Count() > threshold);
        
        if (topRollGroup != null)
            return topRollGroup.Key;
        
        return null;
    }
