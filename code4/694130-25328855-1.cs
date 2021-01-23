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
            protected Stack<string> CallingMethodName = new Stack<string>();
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
                        if (CallingMethodName.Count > 0)
                        {
                            switch (CallingMethodName.Peek())
                            {
                                case "StartsWith":
                                    value = value + "%";
                                    break;
                                case "Contains":
                                    value = "%" + value + "%";
                                    break;
                                case "EndsWith":
                                    value = "%" + value;
                                    break;
                            }
                        }
                        Parameters.Add(value);
                    }
                }
                return returnExpr;
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node != null && node.Method.DeclaringType == typeof(string))
                {
                    CallingMethodName.Push(node.Method.Name);
                    var val = base.VisitMethodCall(node);
                    CallingMethodName.Pop();
                    return val;
                }
                else
                {
                    return base.VisitMethodCall(node);
                }
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterCount++;
                return base.VisitParameter(node);
            }
        }
    }
