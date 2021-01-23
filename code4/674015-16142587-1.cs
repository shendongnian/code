    var itemsGroupedById = SecondList.GroupBy(item => item.id, item => item).ToList();
    var listToReturn = new List<Entity2>();
    foreach(var group in itemsGroupedById)
    {
        var id = group.Key;
        var entityIdsInThisGroup = group.Select(items => items.EntityId).ToList();
        var intersection = entityIdsInThisGroup.Intersect(FirstList).ToList();
        if(intersection.Count == FirstList.Count)
        {
            listToReturn.Add(group);
        }
    }
    return listToReturn;
            
