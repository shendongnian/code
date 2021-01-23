    var query = QueryOver.Of<DomainObject>();
    query = query.Fetch(x => x.Property).Eager;
    query = query.Fetch(x => x.Property.PropertyA).Eager;
    query = query.Fetch(x => x.Property.PropertyB).Eager;
    query = query.Fetch(x => x.Property.PropertyC).Eager;
    // etc
