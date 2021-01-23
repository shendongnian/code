    private void CombineHoldings(List<Holding> holdingsToAdd, ref List<Holding> existingHoldings)
    {
        // group the new holdings by sector
        var groupedHoldings = holdingsToAdd.GroupBy(h => h.Sector);
        // now iterate over the groupings
        foreach(var group in groupedHoldings) {
             // calculate the sum of the percentages in the group
             // we'll need this later
             var sum = group.Sum(h => h.Percentage);
             // get the index of a matching object in existing holdings
             var existingHoldingIndex = existingHoldings.FindIndex(h => h.Sector == group.Key);
             // yay! found one. add the sum of the group and our job's done.
             if(existingHoldingIndex >= 0) {
                 existingHoldings[existingHoldingIndex].Percentage += sum;
                 continue;
             }
             // didn't find one, so take the first holding in the group, set its percentage to the sum
             // and append that to the existing holdings table
             var newHolding = group[0];
             newHolding.Percentage = sum;
             existingHoldings.Add(newHolding);
        }
    }
