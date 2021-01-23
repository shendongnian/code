    var list = new List<IHasProperty>();
    foreach (var item in list)
    {
        item.PropertyAsValueClass = PropertyManager.GetProperty(item.PropertyAsValueClass.Id);
    }
