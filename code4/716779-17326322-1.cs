    // build the entire predicate beforehand (PredicateBuilder + AsQueryable):
    var complexPredicate = GetComplexPredicate();
    var condition = PredicateBuilder.True<Customer>()
        .And(c => c.Country == "US")
        .And(c => c.Invoice.AsQueryable().Any(complexPredicate));
    // apply criteria to query (using Expand):
    var result = repository.Customer.Where(condition.Expand()).ToList();
