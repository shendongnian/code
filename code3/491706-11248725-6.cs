    /// <summary>
    /// A class which contains extension methods for <see cref="Expression"/> and <see cref="Expression{TDelegate}"/> instances.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Remaps all property access from type <typeparamref name="TSource"/> to <typeparamref name="TDestination"/> in <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source element.</typeparam>
        /// <typeparam name="TDestination">The type of the destination element.</typeparam>
        /// <typeparam name="TResult">The type of the result from the lambda expression.</typeparam>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> to remap the property access in.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> equivalent to <paramref name="expression"/>, but applying to elements of type <typeparamref name="TDestination"/> instead of <typeparamref name="TSource"/>.</returns>
        public static Expression<Func<TDestination, TResult>> RemapForType<TSource, TDestination, TResult>(this Expression<Func<TSource, TResult>> expression)
        {
            Contract.Requires(expression != null);
            Contract.Ensures(Contract.Result<Expression<Func<TDestination, TResult>>>() != null);
            
            var newParameter = Expression.Parameter(typeof (TDestination));
            
            Contract.Assume(newParameter != null);
            var visitor = new AutoMapVisitor<TSource, TDestination>(newParameter);
            var remappedBody = visitor.Visit(expression.Body);
            if (remappedBody == null)
                throw new InvalidOperationException("Unable to remap expression");
            
            return Expression.Lambda<Func<TDestination, TResult>>(remappedBody, newParameter);
        }
    }
