    var dbItems = context.FavoriteColor.Select(c => new {
        c.Id,
        c.ColorIndex
    ).ToList();
    
    var items = dbItems.Select(item => new Item {
        Id = item.Id,
        ColorName = Colors.Names.Where(x => x.Index == item.ColorIndex).First().Name
    })
