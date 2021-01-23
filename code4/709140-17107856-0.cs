    var predicate = PredicateBuilder.True<string>();
     if (aCondition)
     {
      predicate = predicate.And(s => s == "this");
     }
     if (bCondition)
     {
      predicate = predicate.And(s => s == "that");
     }
