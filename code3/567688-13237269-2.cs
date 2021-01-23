    public Foo Edit(Foo newFoo)
    {
        var dbFoo = context.Foo
                           .Include(x => x.SubFoo)
                           .Include(x => x.AnotherSubFoo)
                           .Single(c => c.Id == newFoo.Id);
        context.Entry(dbFoo).CurrentValues.SetValues(newFoo);
        context.Entry(dbFoo.SubFoo).CurrentValues.SetValues(newFoo.SubFoo);
        context.Entry(dbFoo.AnotherSubFoo).CurrentValues.SetValues(newFoo.AnotherSubFoo);
        context.SaveChanges();
        return newFoo;
    }
