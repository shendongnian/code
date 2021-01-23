    var outer = PredicateBuilder.True<Product>();
    outer = outer.And (p => p.Price > 100);
    outer = outer.And (p => p.Price < 1000);
    {
       var inner = PredicateBuilder.False<Product>();
       inner = inner.Or (p => p.Description.Contains ("foo"));
       inner = inner.Or (p => p.Description.Contains ("far"));
       outer = outer.And (inner);
    }
