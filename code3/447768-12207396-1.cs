        /// <summary>
        /// Composes two lambda expressions f(y) and g(x), returning a new expression representing f(g(x)).
        /// This is useful for constructing expressions to pass to functions like Where(). If given x => x.Id and id => ids.Contains(id),
        /// for example, you can create the expression x => ids.Contains(x.Id), which could be passed to Where() for an IQueryable of x's type
        /// </summary>
        /// <typeparam name="TIn">The input of g</typeparam>
        /// <typeparam name="TIntermediate">The output of g and the input of f</typeparam>
        /// <typeparam name="TOut">The output of f</typeparam>
        /// <param name="f">The outer function</param>
        /// <param name="g">The inner function</param>
        /// <returns>A new lambda expression</returns>
        public static Expression<Func<TIn, TOut>> Compose<TIn, TIntermediate, TOut>(this Expression<Func<TIntermediate, TOut>> f, Expression<Func<TIn, TIntermediate>> g)
        {
            // The implementation used here gets around EF's inability to process Invoke expressions. Rather than invoking f with the output of g, we
            // effectively "inline" g by replacing all instances of f's parameter with g's body and creating a new lambda with the rebound body of f and
            // the parameters of g
            var map = f.Parameters.ToDictionary(p => p, p => g.Body);            
            var reboundBody = ParameterRebinder.ReplaceParameters(map, f.Body);
            var lambda = Expression.Lambda<Func<TIn, TOut>>(reboundBody, g.Parameters);
            return lambda;
        }
    public class ParameterRebinder : ExpressionVisitor
            { 
                private readonly Dictionary<ParameterExpression, Expression> Map;
    
                public ParameterRebinder(Dictionary<ParameterExpression, Expression> map)
                {
                    this.Map = map ?? new Dictionary<ParameterExpression, Expression>();
                }
    
                public static Expression ReplaceParameters(Dictionary<ParameterExpression, Expression> map, Expression exp)
                {
                    return new ParameterRebinder(map).Visit(exp);
                } 
    
                protected override Expression VisitParameter(ParameterExpression node)
                {
                    Expression replacement;
                    if (this.Map.TryGetValue(node, out replacement))
                    {
                        return this.Visit(replacement);
                    }
                    return base.VisitParameter(node);
                }
            }
