    // DbSet<Foo> will create an IQueryable<Foo>. An Entity Framework IQueryProvider
    // will compile this to an SQL when we want to materialize the query
    IQueryable<Foo> foo = databaseContext.Foo;
    // Now, if this is hit, it's fine because IQueryable.Where returns an IQueryable
    // of the same type. We still live in the 
    if(something)
        foo = foo.Where(f=>f.Bar > 5);
    // Same point as before. foo is still an IQueryable<Foo> and the materialization
    // is not provoked yet.
    if(somethingElse)
        foo = foo.Where(f=>f.Bar > 15);
    // Here, foo.Select() will return an IQueryable<decimal> (or whatever the type
    // of the Foo.Key property is) and then ToList() will get the IEnumerable<decimal>
    // version. At that point, any further manipulation is done through Linq to Object
    // but the query won't be sent to the database until it is iterated (ie
    // the IEnumerable<decimal>.GetEnumerator() is called). The IEnumerable<decimal>
    // version of the will be passed to the List<T>(IEnumerable<T>) constructor
    // which will iterate through the Enumerable with the GetEnumerator method.
    var json = new JavaScriptSerializer.Serialize(new { fooKeys = foo.Select(f => f.Key).ToList() });
    HttpContext.Current.Response.Write(json);
