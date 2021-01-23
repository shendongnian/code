    var items = new List<NameAndOrder>(strs.Count);
    for (var i = 0; i < strs.Count; i++)
    {
        items.Add(new NameAndOrder { Name = strs[i], Order = values[i] });
    }
    items.Sort((a, b) => a.Order.CompareTo(b.Order));
