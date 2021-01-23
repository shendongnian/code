    var method = typeof(Queryable).GetMethod(
        "AsQueryable",
        BindingFlags.Static | BindingFlags.Public, 
        null, 
        new [] { typeof(IEnumerable<RelatedEntity>)}, 
        null);
