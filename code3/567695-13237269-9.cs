    public Foo Edit(Foo newFoo)
    {
        var dbFoo = context.Foo
                           .Include(x => x.SubFoo)
                           .Include(x => x.AnotherSubFoo)
                           .Single(c => c.Id == newFoo.Id);
        // Update foo (works only for scalar properties)
        context.Entry(dbFoo).CurrentValues.SetValues(newFoo);
        // Delete subFoos from database that are not in the newFoo.SubFoo collection
        foreach (var dbSubFoo in dbFoo.SubFoo.ToList())
            if (!newFoo.SubFoo.Any(s => s.Id == dbSubFoo.Id))
                context.SubFoos.Remove(dbSubFoo);
        foreach (var newSubFoo in newFoo.SubFoo)
        {
            var dbSubFoo = dbFoo.SubFoo.SingleOrDefault(s => s.Id == newSubFoo.Id);
            if (dbSubFoo != null)
                // Update subFoos that are in the newFoo.SubFoo collection
                context.Entry(dbSubFoo).CurrentValues.SetValues(newSubFoo);
            else
                // Insert subFoos into the database that are not
                // in the dbFoo.subFoo collection
                dbFoo.SubFoo.Add(newSubFoo);
        }
        // and the same for AnotherSubFoo...
        db.SaveChanges();
        return newFoo;
    }
