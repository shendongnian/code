    class Program {
        static void Main(string[] args) {
            // Retreive your data source
            List<int> numbers = new List<int>() { 0, 10, 20, 30, 40, 50, 60 };
            // Create a collection of predicates that you would like to chain together.
            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "x");
            List<Expression> predicates = new List<Expression>();
            
            // x >= 50
            predicates.Add(Expression.GreaterThanOrEqual(parameterExpression, Expression.Constant(50)));
            // x <= 20
            predicates.Add(Expression.LessThanOrEqual(parameterExpression, Expression.Constant(20)));
            // Build a single predicate by chaining individual predicates together in an OR fashion
            Expression whereFilter = Expression.Constant(false); // Use false a base expression in OR statements
            foreach (var predicate in predicates) {
                whereFilter = Expression.OrElse(whereFilter, predicate);
            }
            
            // Once the expressions have been chained, create a lambda to represent the whole predicate
            // x => (x >= 50) || (x <= 20)
            Expression<Func<int, bool>> whereLambda = 
                (Expression<Func<int, bool>>)Expression.Lambda(whereFilter, 
                                                new List<ParameterExpression>() { parameterExpression });
            
            // To use an expression directly, the datasource must be an IQueryable
            // Since I am using List<T> I must call AsQueryable.  This is not necessary
            // if your collection is already IQueryable, like in Entity Framework.
            var results = numbers.AsQueryable().Where(whereLambda);
        }
    }
