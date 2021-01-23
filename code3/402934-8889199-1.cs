    var groupsInOrder 
        = packageDistribution.GroupBy(p => p.Key.SubString(0,4))
            .OrderBy(g => g.Key);
    foreach(var group in groupsInOrder)
    { 
        int index = 0;
        foreach(var pair in group)
        {
            // Handle item
            if (++index%3==0)
            {
                // New line
            }
        }
        // New line
    }
