    UserProfile alias = null;
    Expression<Func<object>> aliasExpression = () => alias;
    session.QueryOver<Pegfile>()
           .JoinAlias(x => x.UserProfiles, aliasExpression)
           .OrderBy(GetMemberExpression(aliasExpression, "Forename")).Asc
           .List();
    private Expression<Func<object>> GetMemberExpression(Expression<Func<object>> 
                                                           aliasExpression,
                                                         string property)
    {
        var propertyExpression = Expression.Property(aliasExpression.Body,
                                                     typeof(UserProfile), property);
        var body = Expression.Convert(propertyExpression, typeof(object));
        var result = Expression.Lambda<Func<object>>(body);
        return result;
    }
