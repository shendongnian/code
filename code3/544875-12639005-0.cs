    var newItems = new List<Object1> { ...
    IList<Object1> itemsToUpdate = ... 
    var lookup = itemsToUpdate.
            Select((i, o) => new { Key = o.id, Value = i }).
            ToDictionary(i => i.Key, i => i.Value);
    foreach (var newItem in newitems)
    {
        if (lookup.ContainsKey(newitem.ID))
        {
            if (newItem.time > itemsToUpdate[lookup[newItem.Id]].time)
            {
                itemsToUpdate[lookup[newItem.Id]] = newItem;
            }
        }
        else
        {
            itemsToUpdate.Add(newItem)
        }
    }
