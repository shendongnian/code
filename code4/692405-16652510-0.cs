    public static Expression<Func<Message, bool>> GetPredicate(string expression)
    {
        Expression<Func<Message, bool>> result = null;
        try
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Classes.Message), "Message");
            var lambda = DynamicExpression.ParseLambda(new[] { parameter }, null, expression);
            result = (Expression<Func<Message, bool>>)lambda;
        }
        catch (Exception e)
        {
            Log.Fatal(e);
        }
        return result;
    }
