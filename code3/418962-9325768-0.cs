    DbSet<Foo> set = dbContext.Set<Foo>();
    Foo = new Foo { Bar = 5 };
    set.Add(foo);
    
    IEnumerable<Foo> foos = set.Local
                               .Where(f => f.Bar == 5)
                               .Union(set.Where(f => f.Bar == 5)
                                         .AsEnumerable());
    ActOnFoos(foos);
    
    dbContext.SaveChanges();
