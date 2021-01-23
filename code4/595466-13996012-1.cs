    public void CollectValues(Dictionary<string, Dictionary<int, CustomValue>> target)
    {
        foreach(var pair in Values)
        {
            if(target[pair.Key]==null) target.Add(new Dictionary<int, CustomValue>());
            target[pair.Key].Add(pair.ID, pair.Value);
        }
        foreach(var child in Children)
            child.CollectValues(target);
    }
