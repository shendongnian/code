    var param = Expression.Parameter(typeof(Employee), "x");
    var firstCondition = Expression.Lambda<Func<Employee, bool>>(
        Expression.Equal(
            Expression.Property(param, "Id"),
            Expression.Constant(2)
        ),
        param
    );
    var secondCondition = Expression.Lambda<Func<Employee, bool>>(
        Expression.GreaterThan(
            Expression.Property(param, "Id"),
            Expression.Constant(4)
        ),
        param
    );
    var predicateBody = Expression.OrElse(firstCondition.Body, secondCondition.Body);
    var expr = Expression.Lambda<Func<Employee, bool>>(predicateBody, param);
    Console.WriteLine(session.Where(expr).Count());
