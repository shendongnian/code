    using (var ctx = new MyContext())
    {
        var parent = ctx.MyEntities.Include(e => e.Children).FirstOrDefault();
        var children = parent.Children.ToList();
        ctx.MyEntities.Remove(parent);
        foreach (var child in children)
            ctx.MyEntities.Remove(child);
        ctx.SaveChanges();
    }
