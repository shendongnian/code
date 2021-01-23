    public static class GetPropertyNameExtension
    {
        public static string GetPropertyName<TArg, TProperty>(this Expression<Func<TArg, TProperty>> propertyExpression)
        {
            return propertyExpression.Body.GetMemberExpression().GetPropertyName();
        }
        public static string GetPropertyName<TProperty>(this Expression<Func<TProperty>> propertyExpression)
        {
            return propertyExpression.Body.GetMemberExpression().GetPropertyName();
        }
        public static string GetPropertyName(this MemberExpression memberExpression)
        {
            if (memberExpression == null)
            {
                return null;
            }
            if (memberExpression.Member.MemberType != MemberTypes.Property)
            {
                return null;
            }
            var child = memberExpression.Member.Name;
            var parent = GetPropertyName(memberExpression.Expression.GetMemberExpression());
            return parent == null ?
                child
                : parent + "." + child;
        }
        public static MemberExpression GetMemberExpression(this Expression expression)
        {
            if (expression is MemberExpression)
                return (MemberExpression)expression;
            if (expression is UnaryExpression)
                return (MemberExpression)((UnaryExpression)expression).Operand;
            return null;
        }
    }
