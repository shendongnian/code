    using (var ctx = new MyContext())
    {
        var parent = ctx.MyEntities.Include(e => e.Children).FirstOrDefault();
        foreach (var child in parent.Children.ToList())
            ctx.MyEntities.Remove(child);
        ctx.MyEntities.Remove(parent);
        ctx.SaveChanges();
    }
