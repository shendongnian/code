    public static class ExpressionReader
    {
        /// <summary>
        /// Gets the name of the variable or member specified in the lambda.
        /// </summary>
        /// <param name="expr">The lambda expression to analyze. 
        /// The lambda MUST be of the form ()=>variableName.</param>
        /// <returns></returns>
        public static string GetName(this Expression<Func<object>> expr)
        {
            if (expr.Body.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression) expr.Body).Member.Name;
            //most value type lambdas will need this because creating the 
            //Expression from the lambda adds a conversion step.
            if (expr.Body.NodeType == ExpressionType.Convert
                    && ((UnaryExpression)expr.Body).Operand.NodeType 
                         == ExpressionType.MemberAccess)
                return ((MemberExpression)((UnaryExpression)expr.Body).Operand)
                       .Member.Name;
            throw new ArgumentException(
               "Argument 'expr' must be of the form ()=>variableName.");
        }
    }
    public static class ExHelper
    {
        /// <summary>
        /// Throws an ArgumentNullException if the value of any passed expression is null.
        /// </summary>
        /// <param name="expr">The lambda expressions to analyze. 
        /// The lambdas MUST be of the form ()=>variableName.</param>
        /// <returns></returns>
        public static void CheckForNullArg(params Expression<Func<object>>[] exprs)
        {
            foreach (var expr in exprs)
                if(expr.Compile()() == null)
                    throw new ArgumentNullException(expr.GetName());
        }
    }
