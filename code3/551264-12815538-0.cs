    static class Utils
    {
        static readonly Expression<Func<Foo, DateTime>> tranDateTime =
                x => x.TransactionDate.AddMinutes(SqlMethods.DateDiffMinute(
                         x.TransactionTime, new DateTime(1900, 1, 1)));
    
        public static IQueryable<Foo> WhereTransactionDate(
            this IQueryable<Foo> source,
            Expression<Func<DateTime, bool>> predicate)
        {
            var visited = SwapVisitor.Swap(predicate.Body,
                  predicate.Parameters.Single(), tranDateTime.Body);
            var lambda = Expression.Lambda<Func<Foo, bool>>(
                  visited, tranDateTime.Parameters);
            return source.Where(lambda);
        }
    
        class SwapVisitor : ExpressionVisitor
        {
            public static Expression Swap(Expression source,
                 Expression from, Expression to)
            {
                return new SwapVisitor(from, to).Visit(source);
            }
            private SwapVisitor(Expression from, Expression to)
            {
                this.from = from;
                this.to = to;
            }
            readonly Expression from, to;
            public override Expression Visit(Expression node)
            {
                return node == from ? to : base.Visit(node);
            }
        }
    }
