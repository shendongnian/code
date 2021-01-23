    if(ascendingCondition)
    {
       ProductCollection.OrderBy(p => p.Name).ThenBy(p => p.Price)
    }
    else
    {
       ProductCollection.OrderByDescending(p => p.Name).ThenByDescending(p => p.Price)
    }
