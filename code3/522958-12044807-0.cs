    public static class ExpressionReader
    {
        /// <summary>
        /// Gets the name of the variable or member specified in the lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr">The lambda expression to analyze. 
        /// The lambda MUST be of the form ()=>variableName.</param>
        /// <returns></returns>
        public static string GetName<T>(this Expression<Func<T>> expr)
        {
            if (expr.Body.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression) expr.Body).Member.Name;
            throw new ArgumentException(
               "Argument 'expr' must be of the form ()=>variableName.");
        }
    }
    public static class ExHelper
    {
        /// <summary>
        /// Throws an ArgumentNullException if the value of any passed expression is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr">The lambda expressions to analyze. 
        /// The lambdas MUST be of the form ()=>variableName.</param>
        /// <returns></returns>
        public static void CheckForNullArg<T>(params Expression<Func<T>>[] expr)
        {
            if(expr.Compile()() == null)
                throw new ArgumentNullException(expr.GetName());
        }
    }
