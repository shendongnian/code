    private Expression<Func<T, bool>> ExpressionIsNamed(IEnumerable<EntityName> AccessorNames)
    {
        Expression<Func<T, IEnumerable<EntityName>>> accessList = (x) => x.Security.Readers;
        Expression<Func<IEnumerable<EntityName>, bool>> accessCheck = AccessCheckExpression(AccessorNames);
        var result = Expression.Lambda<Func<T, bool>>(
            Expression.Invoke(accessCheck, accessList.Body), // make invokation of accessCheck, and provide body of accessList (x.Security.Readers) as parameter
            accessList.Parameters.First() // parameter
        );
        return result;
    }
