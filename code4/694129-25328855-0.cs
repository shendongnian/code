    public static class ExpressionExtension
    {
        public static object[] GetParameters(this Expression expr)
        {
            var fetcher = new ParameterFetcher();
            fetcher.Visit(expr);
            return fetcher.Parameters.ToArray();
        }
        class ParameterFetcher : System.Linq.Expressions.ExpressionVisitor
        {
            public readonly List<object> Parameters = new List<object>();
            protected int ParameterCount { get; set; }
            protected int MemberCount { get; set; }
            protected override Expression VisitMember(MemberExpression node)
            {
                var count = ParameterCount;
                MemberCount++;
                var returnExpr = base.VisitMember(node);
                MemberCount--;
                if (MemberCount == 0 && count == ParameterCount)
                {
                    var baseType = Nullable.GetUnderlyingType(node.Type) ?? node.Type;
                    if (baseType == typeof(string) || baseType.IsValueType == true)
                    {
                        var objectMember = Expression.Convert(node, typeof(object));
                        var getterLambda = Expression.Lambda<Func<object>>(objectMember);
                        var value = getterLambda.Invoke();
                        Parameters.Add(value);
                    }
                }
                return returnExpr;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterCount++;
                return base.VisitParameter(node);
            }
        }
    }
