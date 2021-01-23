    public static class ParameterReplacer
    {
        // Produces an expression identical to 'expression'
        // except with 'source' parameter replaced with 'target' expression.     
        public static Expression<TOutput> Replace<TInput, TOutput>
                        (Expression<TInput> expression,
                        ParameterExpression source,
                        Expression target)
        {
            return new ParameterReplacerVisitor<TOutput>(source, target)
                        .VisitAndConvert(expression);
        }
    
        private class ParameterReplacerVisitor<TOutput> : ExpressionVisitor
        {
            private ParameterExpression _source;
            private Expression _target;
    
            public ParameterReplacerVisitor
                    (ParameterExpression source, Expression target)
            {
                _source = source;
                _target = target;
            }
    
            internal Expression<TOutput> VisitAndConvert<T>(Expression<T> root)
            {
                return (Expression<TOutput>)VisitLambda(root);
            }
    
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                // Leave all parameters alone except the one we want to replace.
                var parameters = node.Parameters
                                     .Where(p => p != _source);
    
                return Expression.Lambda<TOutput>(Visit(node.Body), parameters);
            }
    
            protected override Expression VisitParameter(ParameterExpression node)
            {
                // Replace the source with the target, visit other params as usual.
                return node == _source ? _target : base.VisitParameter(node);
            }
        }
    }
