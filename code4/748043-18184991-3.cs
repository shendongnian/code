    Type targetType = typeof(MyClass);
    var obj = Expression.Variable(targetType);
    var creatorExpression = Expression.New(targetType);
    var assign = Expression.Assign(obj, creatorExpression);
    var prop = Expression.PropertyOrField(obj, "MyProp1");
    var value = Expression.Constant(5);
    var member = Expression.Assign(prop, value);
    var block = Expression.Block(new[] { obj }, creatorExpression, assign, member);
