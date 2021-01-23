    using (var ctx = new MyContext())
    {
        var objectA = ctx.ObjectAs.Include("list").Single(o => o.Id == someId);
        objectA.list.Clear();
        ctx.SaveChanges();
    }
