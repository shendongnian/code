    var paramX = Expression.Parameter(typeof(Foo), "x"); // x
    var paramY = Expression.Parameter(typeof(Foo), "y"); // y
        
    var xDate = Expression.Property(paramX, "EFFECTIVE_DATE"); // x.EFFECTIVE_DATE
    var yDate = Expression.Property(paramY, "EFFECTIVE_DATE"); // y.EFFECTIVE_DATE
    
    // DateTime.Compare(y.EFFECTIVE_DATE, x.EFFECTIVE_DATE)
    var body = Expression.Call(typeof(DateTime).GetMethod("Compare"), yDate, xDate);
    
    // (x, y) => DateTime.Compare(y.EFFECTIVE_DATE, x.EFFECTIVE_DATE)
    var expr = Expression.Lambda<Func<Foo, Foo, int>>(body, paramX, paramY);
