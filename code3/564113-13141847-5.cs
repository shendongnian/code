    public static class CmpExtension
    {
        public static bool Cmp<T, TProperty>(this T obj, Expression<Func<T, TProperty>> compareExpression)
        {
            // The expression should be a binary expression.
            var binaryExpression = compareExpression.Body as BinaryExpression;
            // Left side of comparison (should be a property)
            var memberExpression = binaryExpression.Left as MemberExpression;
            var childMemberExpression = memberExpression.Expression as MemberExpression;
            var childPropertyInfo = childMemberExpression.Member as PropertyInfo;
            var childPropertyValue = childPropertyInfo.GetValue(obj, null);
            var propertyInfo = memberExpression.Member as PropertyInfo;
            var propertyValue = propertyInfo.GetValue(childPropertyValue, null);
            // Right side of comparison
            var constantExpression = binaryExpression.Right as ConstantExpression;
            var compareValue = constantExpression.Value;
            return propertyValue == compareValue;
        }
    }
