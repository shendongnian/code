    // Maps operators to Expression factory methods
    var dict = new Dictionary<string, Func<Expression, Expression, BinaryExpression>>
    {
        { "==", Expression.Equal },
        { ">", Expression.GreaterThan },
        { "<", Expression.LessThan },
        // etc
    };
    var predicate = Expression.Constant(true); // by default accept all rows
    // Logical AND everything in parseResult to construct the final predicate
    foreach (parseResult in parsedUserInput)
    {
        var exprConstructor = dict[parseResult.Operator];
        var property = sourceType.GetProperty(parseResult.PropertyName);
        var target = Expression.MakeMemberAccess(variable, property);
        var additionalTest = exprConstructor(target, Expression.Constant(parseResult.Value));
        predicate = Expression.AndAlso(predicate, additionalTest);
    }
