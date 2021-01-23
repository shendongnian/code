        public static IEnumerable<string> GetPropertiesNames<T, G>(this Expression<Func<T, G>> pathExpression)
        {
            List<string> _propertyNames = new List<string>();
            Expression expression = pathExpression.Body;
            if (expression.NodeType == ExpressionType.Convert)
            {
                var convert = (UnaryExpression)pathExpression.Body;
                expression = convert.Operand;
            }
            while (expression.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)expression;
                  if(!(memberExpression.Member is PropertyInfo)) 
                        throw new InvalidOperationException();
                _propertyNames.Add(memberExpression.Member.Name);
                expression = memberExpression.Expression;
            }
            if (expression.NodeType != ExpressionType.Parameter)
                throw new InvalidOperationException();
            return _propertyNames;
        }
