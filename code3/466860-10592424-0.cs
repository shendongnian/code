    class Program
    {
        static void Main(string[] args)
        {
            var seq = new[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            var query = seq.OrderBy(x => x);
            Console.WriteLine("Print out in reverse order.");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Prints out in original order");
            var queryExpression = seq.AsQueryable().OrderBy(x => x).ThenByDescending(x => x).Expression;
            var queryDelegate = Expression.Lambda<Func<IEnumerable<int>>>(new OrderByRemover().Visit(queryExpression)).Compile();
            foreach (var item in queryDelegate())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
    public class OrderByRemover : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType != typeof(Enumerable) && node.Method.DeclaringType != typeof(Queryable))
                return base.VisitMethodCall(node);
            if (node.Method.Name != "OrderBy" && node.Method.Name != "OrderByDescending" && node.Method.Name != "ThenBy" && node.Method.Name != "ThenByDescending")
                return base.VisitMethodCall(node);
            //eliminate the method call from the expression tree by returning the object of the call.
            return base.Visit(node.Arguments[0]);
        }
    }
