    var exceptItems = AllItems.Rows.Cast<DataRow>()
        .Select((i, index) => new { id = i["Id"], index })
        .Intersect(Items.Rows.Cast<DataRow>()
            .Select((i, index) => new { id = i["Id"], index }))
        .ToList();
    for (int i = exceptItems.Count()-1; i >= 0; i--)
    {
        AllItems.Rows.RemoveAt(exceptItems[i].index);
    }
