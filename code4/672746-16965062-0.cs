    public static IQueryable<TResult> WithInfo<TResult>(this IQueryable<Ticket> q, Expression<Func<Ticket, string, TResult>> resultSelector, int digitsCount)
    {
        return SelectTickets(q.Select(T => new
        {
            Ticket = T,
            Text = T.Name + "123"
        }), resultSelector);
    }
    private static IQueryable<TResult> SelectTickets<T, TResult>(IQueryable<T> sequence, Expression<Func<Ticket, string, TResult>> resultSelector)
    {
        ParameterExpression param = Expression.Parameter(typeof(T));
        ParameterExpression param1 = Expression.Parameter(typeof(Ticket));
        ParameterExpression param2 = Expression.Parameter(typeof(string));
        MemberExpression prop1 = Expression.Property(param, "Ticket");
        MemberExpression prop2 = Expression.Property(param, "Text");
        var lambda = Expression.Lambda<Func<T, TResult>>(Expression.Invoke(resultSelector, prop1, prop2), param);
        return sequence.Select(lambda);
    }
