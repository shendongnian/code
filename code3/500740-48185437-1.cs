    IQueryable<Foo> q = [Your database context].Foos.AsQueryable();
    IQueryable<Foo> p = null;
    p = q.OrderBy("myBar.name");  // Ascending sort
    // Or
    p = q.OrderBy("myBar.name", false);  // Descending sort
    // Materialize
    var result = p.ToList();
