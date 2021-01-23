    using (var ctx = new MyEntities())
    {
      var items =
        ctx.Items.Select(
            i => new ItemModel
            {
                Id = i.Id,
                Name = i.ChildItems.FirstOrDefault(x=>languages.Any(k=>k == x.Language)).Name                 
            });
    }
