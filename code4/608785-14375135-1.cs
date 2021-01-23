    var apiMenuItems = menuItems.ToList().Select(item => new ApiMenuItem()
    {
        ID = item.ID,
        Name = item.Name.GetLocalizedString("en")
    });
