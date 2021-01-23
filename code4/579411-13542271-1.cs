    static Foo[] SearchFoo(string name, int? age, string region)
    {
        using (var ctx = GetContext())
        {
            IQueryable<Foo> query = ctx.Foos;
            if(name != null) query = query.Where(f => f.Name == name);
            if(age != null) query = query.Where(f => f.Age == age);
            if(region != null) query = query.Where(f => f.Region == region);
            return ctx.ToArray();
        }
    }
