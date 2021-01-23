    // Some intermediate variables to cut down on the line length
    var itemProperty = eventArgsType.GetProperty("Item");
    var itemAccessExpression = Expression.MakeMemberAccess(parameters[1], itemProperty);
    var castItemToCorrectType = Expression.TypeAs(itemAccessExpression, sourceType);
    // And the body is comprised of these two expressions:
    var body = new[] { Expression.Assign(variable, castItemToCorrectType), predicate };
