    public static IQueryable<T> FieldsAreEqualOrBothNullOrEmpty<T>(
        this IQueryable<T> source,
        Expression<Func<T, string>> member, string value)
    {
        Expression body;
        if (string.IsNullOrEmpty(value))
        {
            body = Expression.Call(
                typeof(string), "IsNullOrEmpty", null, member.Body);
        }
        else
        {
            body = Expression.Equal(
                Expression.Call(member.Body, "ToLower", null),
                Expression.Constant(value.ToLower(), typeof(string)));
        }
        return source.Where(Expression.Lambda<Func<T,bool>>(
            body, member.Parameters));
    }
