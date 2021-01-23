    private Expression<Func<T, bool>> ExpressionIsNamed(
        IEnumerable<EntityName> AccessorNames)
    {
        Expression<Func<T, IEnumerable<EntityName>>> accessList =
            (T x) => x.Security.Readers;
        Expression<Func<IEnumerable<EntityName>, bool>> accessCheck =
            SecurityDescriptor.AccessCheckExpression(AccessorNames);
        var body = SwapVisitor.Swap(accessCheck.Body,
            accessCheck.Parameters[0], accessList.Body);
        return Expression.Lambda<Func<T, bool>>(body, accessList.Parameters);
    }
