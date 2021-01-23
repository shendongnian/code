    using (var ctx = new EFContext())
    {
        Person p = ctx.People.Include(x => x.Address).First();
        //p.Address IS NOT NULL!
        p.Address = null;
        var entry = ctx.Entry(p);
    }
