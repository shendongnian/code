        public class WhereContainsTreeModifier : ExpressionVisitor
        {
            private Expression TranslateContains(LambdaExpression lambda)
            {
                var methodCall = lambda.Body as MethodCallExpression;
                var member = methodCall.Object as MemberExpression;
                var objectMember = Expression.Convert(member, typeof(object));
                var getterLambda = Expression.Lambda<Func<object>>(objectMember);
                var getter = getterLambda.Compile();
                var list = (IEnumerable)getter();
                Expression result = null;
                foreach (object item in list)
                {
                    var equal = Expression.Equal(methodCall.Arguments[0], Expression.Constant(item));
                    if (result == null)
                        result = equal;
                    else
                        result = Expression.OrElse(result, equal);
                }
                result = Expression.Lambda(lambda.Type, result, lambda.Parameters);
                return result;
            }
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if ((node.Body as MethodCallExpression).Method.Name == "Contains")
                    return TranslateContains(node);
                else
                    return node;
            }
        }
