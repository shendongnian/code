    using (ISampleRepository repo = new SampleRepository())
    {
        var predicates = new List<Expression<Func<Customer,bool>>>(){
            (x => x.FirstName.Contains(searchValue)),
            (x => x.LastName.Contains(searchValue))
        };
    
        var lambda = PredicateBuilder.False<Customer>();
        lambda = predicates.Aggregate(lambda, (current, p) => current.Or(p).Expand());
    
        var query = repo.QueryCustomers().AsExpandable().Include(x => x.Phones).Where(lambda);
        return query.Take(500)
            .ToList()
            .Select(x => x.ToDTO())
            .ToList();
    }
