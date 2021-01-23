    public static class PropertyNameExtractor
    {
        /// <summary>
        /// Usage: PropertyNameExtractor.ExposeProperty(() => this.YourProperty)
        /// yields: "YourProperty"
        /// </summary>
        public static string ExposeProperty<T>(Expression<Func<T>> property)
        {
            var expression = GetMemberInfo(property);
            return expression.Member.Name;
        }
        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");
            MemberExpression memberExpr = null;
            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }
            if (memberExpr == null)
                throw new ArgumentException("method");
            return memberExpr;
        }
    }
