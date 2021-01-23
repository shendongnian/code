    Expression<Func<T,bool>> Combine<T,TNav>(Expression<Func<T,TNav>> parent, Expression<Func<TNav,bool>> nav)
    {
         var param = Expression.Parameter(typeof(T), "x");
         var visitor = new ReplacementVisitor(parent.Parameters[0], param);
         var newParentBody = visitor.Visit(parent.Body);
         visitor = new ReplacementVisitor(nav.Parameters[0], newParentBody);
         var body = visitor.Visit(nav.Body);
         return Expression.Lambda<Func<T, bool>>(body, param);
    }
    
    public class ReplacementVisitor : System.Linq.Expressions.ExpressionVisitor
    {
        private readonly Expression _oldExpr;
        private readonly Expression _newExpr;
        public ReplacementVisitor(Expression oldExpr, Expression newExpr)
        {
            _oldExpr = oldExpr;
            _newExpr = newExpr;
        }
        
        public override Expression Visit(Expression node)
        {
            if (node == _oldExpr)
                return _newExpr;
            return base.Visit(node);
        }
        
    }
