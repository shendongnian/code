    using (var ctx = new MyContext())
    {
        var parent = ctx.MyEntities
            .Include(e => e.Children)
            .FirstOrDefault();
    
        var deleteme = parent.Children.First();
    
        ctx.DeleteMyEntity(deleteme);
    }
