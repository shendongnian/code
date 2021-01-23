    var objects = new List<ISharedApi>();
    objects.Add(new SubClassOne());
    objects.Add(new SubClassTwo());
    foreach (var item in objects)
    {
       item.Main();
    }
       
