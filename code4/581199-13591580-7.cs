    public static class Helper
    {
        public static MvcHtmlString GetElementID<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return MvcHtmlString.Create(GetPropertyName(expression));
        }
        
        private static string GetPropertyName(Expression lambdaExpression)
        {
            IList<string> list = new List<string>();
            var e = lambdaExpression;
            while (true)
            {
                switch (e.NodeType)
                {
                    case ExpressionType.Lambda:
                        e = ((LambdaExpression)e).Body;
                        break;
                    case ExpressionType.MemberAccess:
                        var propertyInfo = ((MemberExpression)e).Member as PropertyInfo;
                        var prop = propertyInfo != null
                                          ? propertyInfo.Name
                                          : null;
                        list.Add(prop);
                        var memberExpression = (MemberExpression)e;
                        if (memberExpression.Expression.NodeType != ExpressionType.Parameter)
                        {
                            var parameter = GetParameterExpression(memberExpression.Expression);
                            if (parameter != null)
                            {
                                e = Expression.Lambda(memberExpression.Expression, parameter);
                                break;
                            }
                        }
                        return string.Join("_", list.Reverse());
                    default:
                        return null;
                }
            }
        }
        private static ParameterExpression GetParameterExpression(Expression expression)
        {
            while (expression.NodeType == ExpressionType.MemberAccess)
            {
                expression = ((MemberExpression)expression).Expression;
            }
            return expression.NodeType == ExpressionType.Parameter ? (ParameterExpression)expression : null;
        }
    }
