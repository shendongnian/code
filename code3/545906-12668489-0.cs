    foreach(var thing in ctx.YourDbSet.Select(p=> new { Id = p.Id, Name = p.Name}))
    {
        var dummy = new YourEntity{Id = thing.Id};
        ctx.YourDbSet.Attach(dummy);
        dummy.Name = thing.Name + "_";
    }
    ctx.SaveChanges();
