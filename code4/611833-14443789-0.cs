    public static string Item<TItem, TMember>(this TItem obj, Expression<Func<TItem, TMember>> expression)
    {
        if (expression.Body is MemberExpression)
        {
            return ((MemberExpression)(expression.Body)).Member.Name;
        }
        if (expression.Body is UnaryExpression)
        {
            return ((MemberExpression)((UnaryExpression)(expression.Body)).Operand).Member.Name;
        }
        if (expression.Body is ParameterExpression)
        {
            return expression.Body.Type.Name;
        }
        throw new InvalidOperationException();
    }
   
