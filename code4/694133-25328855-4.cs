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
            protected Stack<string> CallingStringMethod = new Stack<string>();
            protected int Visited = 0;
            protected override Expression VisitMember(MemberExpression node)
            {
                if (Visited > 0)
                {
                    Visited--;
                }
                else
                {
                    var member = node;
                    while (member != null && member.Expression is MemberExpression)
                    {
                        member = (MemberExpression)member.Expression;
                        Visited++;
                    }
                    if (member != null && member.Expression.NodeType == ExpressionType.Constant)
                    {
                        var baseType = Nullable.GetUnderlyingType(node.Type) ?? node.Type;
                        if (baseType == typeof(string) || baseType == typeof(Guid) || baseType.IsPrimitive == true)
                        {
                            var objectMember = Expression.Convert(node, typeof(object));
                            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
                            var value = getterLambda.Invoke();
                            if (value != null && CallingStringMethod.Count > 0)
                            {
                                switch (CallingStringMethod.Peek())
                                {
                                    case "StartsWith":
                                        value = Convert.ToString(value).Replace("[", "[[]").Replace("_", "[_]").Replace("%", "[%]") + "%";
                                        break;
                                    case "Contains":
                                        value = "%" + Convert.ToString(value).Replace("[", "[[]").Replace("_", "[_]").Replace("%", "[%]") + "%";
                                        break;
                                    case "EndsWith":
                                        value = "%" + Convert.ToString(value).Replace("[", "[[]").Replace("_", "[_]").Replace("%", "[%]");
                                        break;
                                }
                            }
                            Parameters.Add(value);
                        }
                    }
                }
                return base.VisitMember(node);
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node != null && node.Method.DeclaringType == typeof(string))
                {
                    switch (node.Method.Name)
                    {
                        case "StartsWith":
                        case "Contains":
                        case "EndsWith":
                            CallingStringMethod.Push(node.Method.Name);
                            var val = base.VisitMethodCall(node);
                            CallingStringMethod.Pop();
                            return val;
                    }
                }
                return base.VisitMethodCall(node);
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return base.VisitParameter(node);
            }
        }
    }
