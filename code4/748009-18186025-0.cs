    var languages = new List<string> {"DE", "EN", "FR"};//Can add more
    using (var ctx = new MyEntities())
    {
      var items =
        ctx.Items.Select(
            i => new ItemModel
            {
                Id = i.Id,
                Name = languages.Select(lang=> i.ChildItems
                                                .FirstOrDefault(x=>x.Language == lang))
                                .FirstOrDefault(x=>x!=null).Name;//Suppose the default value of ChildItem is null (a reference type).
            });
    }
