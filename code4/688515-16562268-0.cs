    public static PropertyInfo GetProperty<T>(this Expression<Func<T, dynamic>> expression)
            {
                MemberExpression memberExpression = null;
    
                if (expression.Body.NodeType == ExpressionType.Convert)
                {
                    memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
                }
                else if (expression.Body.NodeType == ExpressionType.MemberAccess)
                {
                    memberExpression = expression.Body as MemberExpression;
                }
    
                if (memberExpression == null)
                {
                    throw new ArgumentException("Not a member access", "expression");
                }
    
                return memberExpression.Member as PropertyInfo;
            }
