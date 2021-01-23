    var predicate = PredicateBuilder.True<MovieList>();
    
    foreach (var filter in filters)
    {
        string filter1 = filter;
        predicate = predicate.And(a => a.filter.FieldName == filter1);
    }
    return movies.AsExpandable().Where(predicate);
