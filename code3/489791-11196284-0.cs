    var where = new List<Expression<Func<Person, bool>>>();
    if (!string.IsNullOrWhitespace(lastName))
        where.Add(p => p.LastName == lastName);
    if (!string.IsNullOrWhitespace(firstName))
        where.Add(p => p.FirstName == firstName);
    // etc...
    var query = session.Query<Person>();
    foreach (var clause in where)
        query = query.Where(clause);
    var results = query.ToList();
