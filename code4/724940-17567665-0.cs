    // databaseContext.Foo is a (presumably) DbSet<Foo> that implements 
    // IQueryable<Foo>. Because the variable foo is set to be an IEnumerable<Foo> 
    // and that IQueryable<Foo> implements IEnumerable<Foo> by calling 
    // as AsEnumerable(), any further manipulation of the IEnumerable<Foo>
    // will be with LINQ to Object and not Linq to SQL (with Entity Framework)
    IEnumerable<Foo> foo = databaseContext.Foo;
    // Because of the previous point, this will potentially execute the query
    if(something)
        foo = foo.Where(f=>f.Bar > 5);
    // And this will as well
    if(somethingElse)
        foo = foo.Where(f=>f.Bar > 15);
    // And ToList() will definitely execute it.
    var json = new JavaScriptSerializer.Serialize(new { fooKeys = foo.Select(f => f.Key).ToList() });
    HttpContext.Current.Response.Write(json);
