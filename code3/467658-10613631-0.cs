    using System;
    using System.Linq.Expressions;
    
    class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
    
    static class Program
    {
        static void Main()
        {
            Expression<Func<MyEntity, bool>> e1 = i => i.FName.Contains("john");
            Expression<Func<MyEntity, bool>> e2 = i => i.LName.Contains("smith");
    
            // rewrite e1, using the parameter from e2; "&&"
            var lambda1 = Expression.Lambda<Func<MyEntity, bool>>(Expression.AndAlso(
                new SwapVisitor(e1.Parameters[0], e2.Parameters[0]).Visit(e1.Body),
                e2.Body), e2.Parameters);
            // rewrite e1, using the parameter from e2; "||"
            var lambda2 = Expression.Lambda<Func<MyEntity, bool>>(Expression.OrElse(
                new SwapVisitor(e1.Parameters[0], e2.Parameters[0]).Visit(e1.Body),
                e2.Body), e2.Parameters);
        }
    }
