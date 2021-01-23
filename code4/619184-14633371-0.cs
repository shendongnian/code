    static class ContainsAny
    {
        private static readonly MethodInfo StringContains 
           = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        
        public static Builder<T> Words<T>(IEnumerable<string> words)
        {
            return new Builder<T>(words);
        }    
        
        public static Builder<T> Words<T>(params string[] words)
        {
            return new Builder<T>(words);
        }    
        
        public sealed class Builder<T>
        {
            private static readonly ParameterExpression Parameter 
               = Expression.Parameter(typeof(T), "obj");
            
            private readonly List<Expression> _properties = new List<Expression>();
            private readonly List<ConstantExpression> _words;
            
            internal Builder(IEnumerable<string> words)
            {
                _words = words
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Select(word => Expression.Constant(word))
                    .ToList();
            }
            
            public Builder<T> WithProperty(Expression<Func<T, string>> property)
            {
                if (_words.Count != 0)
                {
                    _properties.Add(ReplacementVisitor.Transform(
                        property, property.Parameters[0], Parameter));
                }
                
                return this;
            }
            
            private Expression BuildProperty(Expression prop)
            {
                return _words
                  .Select(w => (Expression)Expression.Call(prop, StringContains, w))
                  .Aggregate(Expression.OrElse);
            }
            
            public Expression<Func<T, bool>> Build()
            {
                if (_words.Count == 0) return (T obj) => true;
                
                var body = _properties
                    .Select(BuildProperty)
                    .Aggregate(Expression.OrElse);
                
                return Expression.Lambda<Func<T, bool>>(body, Parameter);
            }
        }
        
        private sealed class ReplacementVisitor : ExpressionVisitor
        {
            private ICollection<ParameterExpression> Parameters { get; set; }
            private Expression Find { get; set; }
            private Expression Replace { get; set; }
            
            public static Expression Transform(
                LambdaExpression source, 
                Expression find, 
                Expression replace)
            {
                var visitor = new ReplacementVisitor
                {
                    Parameters = source.Parameters,
                    Find = find,
                    Replace = replace,
                };
                
                return visitor.Visit(source.Body);
            }
            
            private Expression ReplaceNode(Expression node)
            {
                return (node == Find) ? Replace : node;
            }
            
            protected override Expression VisitConstant(ConstantExpression node)
            {
                return ReplaceNode(node);
            }
            
            protected override Expression VisitBinary(BinaryExpression node)
            {
                var result = ReplaceNode(node);
                if (result == node) result = base.VisitBinary(node);
                return result;
            }
            
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (Parameters.Contains(node)) return ReplaceNode(node);
                return Parameters.FirstOrDefault(p => p.Name == node.Name) ?? node;
            }
        }
    }
