    var userquery = session.CreateCriteria(typeof(User))
        .Add(Restrictions.Like("UpperEmail", emailToMatch.ToUpper()))
        .SetFirstResult(pageIndex * pageSize)
        .SetMaxResults(pageSize);
    var totalcountQuery = CriteriaTransformer.Clone(userquery)
        .SetProjection(Projections.RowCountInt64()));
    IEnumerable<User> dbUsers = userquery.Future<User>();
    IFutureValue<long> count = totalcountQuery.FutureValue<long>();
    totalcount = count.Value;  // both will be executed here
    foreach ( User u in dbUsers)
