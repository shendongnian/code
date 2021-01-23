    using System;
    using System.Linq.Expressions;
    
    static class Program
    {
        static void Main()
        {
            Expression<Func<Foo, bool>> filter = x => x.A > 1;
            
            bool applySecondFilter = true;
            if(applySecondFilter)
            {
                filter = Combine(filter, x => x.B > 2.5);
            }
            var data = repo.Get(filter);
        }
        static Expression<Func<T,bool>> Combine<T>(Expression<Func<T,bool>> filter1, Expression<Func<T,bool>> filter2)
        {
            // combine two predicates:
            // need to rewrite one of the lambdas, swapping in the parameter from the other
            var rewrittenBody1 = new ReplaceVisitor(
                filter1.Parameters[0], filter2.Parameters[0]).Visit(filter1.Body);
            var newFilter = Expression.Lambda<Func<T, bool>>(
                Expression.And(rewrittenBody1, filter2.Body), filter2.Parameters);
            return newFilter;
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
