    using System;
    using System.Linq.Expressions;
    
    static class Program
    {
        static void Main()
        {
            Expression<Func<Foo, bool>> filter1 = x => x.A > 1;
            Expression<Func<Foo, bool>> filter2 = x => x.B > 2.5;
    
            // combine two predicates:
            // need to rewrite one of the lambdas, swapping in the parameter from the other
            var rewrittenBody1 = new ReplaceVisitor(
                filter1.Parameters[0], filter2.Parameters[0]).Visit(filter1.Body);
            var newFilter = Expression.Lambda<Func<Foo, bool>>(
                Expression.AndAlso(rewrittenBody1, filter2.Body), filter2.Parameters);
            // newFilter is equivalent to: x => x.A > 1 && x.B > 2.5
        }
    }
    class Foo
    {
        public int A { get; set; }
        public float B { get; set; }
    }
    class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
