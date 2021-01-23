    public static string GetPropertyName<TClass, TProperty>(
        Expression<Func<TClass, TProperty>> entityPropertyExpression)
    {
        return ((MemberExpression)entityPropertyExpression.Body).Member.Name;
    }
 
