    var predicate = PredicateBuilder.True<keywordQuery>();
    foreach (string s in splitKeywords) {
        predicate.AND(s.Contains(k.Name));
    }
    
    query.Where(predicate);
