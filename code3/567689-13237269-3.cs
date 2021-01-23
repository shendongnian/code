    public Foo Edit(Foo newFoo)
    {
        var dbFoo = context.Foo
                           .Include(x => x.SubFoo)
                           .Include(x => x.AnotherSubFoo)
                           .Single(c => c.Id == newFoo.Id);
        context.Entry(dbFoo).CurrentValues.SetValues(newFoo);
        if (dbFoo.SubFoo != null)
        {
            if (newFoo.SubFoo != null)
            {
                if (dbFoo.SubFoo.Id == newFoo.SubFoo.Id)
                    // no relationship change, only scalar prop.
                    context.Entry(dbFoo.SubFoo).CurrentValues.SetValues(newFoo.SubFoo);
                else
                {
                    // Relationship change
                    // Attach assumes that newFoo.SubFoo is an existing entity
                    context.SubFoos.Attach(newFoo.SubFoo);
                    dbFoo.SubFoo = newFoo.SubFoo;
                }
            }
            else // relationship has been removed
                dbFoo.SubFoo = null;
        }
        else
        {
            if (newFoo.SubFoo != null) // relationship has been added
            {
                // Attach assumes that newFoo.SubFoo is an existing entity
                context.SubFoos.Attach(newFoo.SubFoo);
                dbFoo.SubFoo = newFoo.SubFoo;
            }
            // else -> old and new SubFoo is null -> nothing to do
        }
        
        // the same logic for AnotherSubFoo ...
        context.SaveChanges();
        return newFoo;
    }
