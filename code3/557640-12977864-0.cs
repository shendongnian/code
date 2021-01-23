    Dictionary<Item, Dictionary<Item, Count>> combine = new Dictionary<Item, Dictionary<Item, Count>>();
    
    foreach (Item item in Sell)
    {
        Dictionary<Item, int> key;
        if (!combine.TryGetValue(item, out key))
        {
            key = new Dictionary<Item, Count>();
            combine.Add(item, key);
        }
    
        foreach (Item otherItem in Sell)
        {
            if (item == otherItem)
                continue;
    
            Count count;
            if (key.TryGetValue(otherItem, out count))
                count++;
            else
                key.Add(otherItem, new Count());
        }
    }
