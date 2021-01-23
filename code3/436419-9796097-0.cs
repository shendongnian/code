        static void Main(string[] args)
        {
            const string exp = "(A*B) + C";
            var p0 = Expression.Parameter(typeof(int), "A");
            var p1 = Expression.Parameter(typeof(int), "B");
            var p2 = Expression.Parameter(typeof(int), "C");
            var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p0, p1, p2 }, typeof(int), exp);
            var result = e.Compile().DynamicInvoke(2, 3, 6);
            Console.WriteLine(result);
            Console.ReadKey();
        }
