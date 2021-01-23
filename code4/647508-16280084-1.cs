    public static class FunctionalExtensions
    {
        public static Expression<Func<TInput,TResult>> ComposeWith<TInput,TParam,TResult>(
            this Expression<Func<TParam,TResult>> left, Expression<Func<TInput,TParam>> right)
        {
            var param = left.Parameters.Single();
            
            var visitor = new ParameterReplacementVisitor(p => {
                if (p == param)
                {
                    return right.Body;
                }
                return null;
            });
            
            return Expression.Lambda<Func<TInput,TResult>>(
                visitor.Visit(left.Body),
                right.Parameters.Single());
        }
    
        private class ParameterReplacementVisitor : ExpressionVisitor
        {
            private Func<ParameterExpression, Expression> _replacer;
            
            public ParameterReplacementVisitor(Func<ParameterExpression, Expression> replacer)
            {
                _replacer = replacer;
            }
            
            protected override Expression VisitParameter(ParameterExpression node)
            {
                var replaced = _replacer(node);
                return replaced ?? node;
            }
        }
    }
