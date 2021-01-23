    var capture = new SecretType();
    capture.i = ...
    var p = Expression.Parameter("x", typeof(int));  
    Expression<Func<int,int>> func = Expression.Lambda<Func<int,int>>(
        Expression.Multiply(
            Expression.Multiply(Expression.Constant(2),p),
            Expression.PropertyOrField(Expression.Constant(capture), "i")
        ), p);
