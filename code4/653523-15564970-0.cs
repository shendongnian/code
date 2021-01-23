    using System;
    using System.Linq;
    using System.Linq.Expressions;
    static class Program
    {
        static void Main()
        {
            var data = new[] { new Foo { A = "x1", B = "y1", C = "y1" }, new Foo { A = "y2", B = "y2", C = "y2" },
                new Foo { A = "y3", B = "y3", C = "x3" } }.AsQueryable();
    
            var result = data.Search("x", x => x.A, x => x.B, x => x.C);
    
            foreach (var row in result)
            {
                Console.WriteLine("{0}, {1}, {2}", row.A, row.B, row.C);
            }
        }
        class Foo
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
        }
        public class SwapVisitor : ExpressionVisitor
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
            public static Expression Swap(Expression body, Expression from, Expression to)
            {
                return new SwapVisitor(from, to).Visit(body);
            }
        }
        public static IQueryable<TSource> Search<TSource>(this IQueryable<TSource> source, string searchTerm, params Expression<Func<TSource, string>>[] stringProperties)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }
            if (stringProperties.Length == 0) return source.Where(x => false);
    
    
            // The lamda I would like to reproduce:
            // source.Where(x => x.[property1].Contains(searchTerm)
            //                || x.[property2].Contains(searchTerm)
            //                || x.[property3].Contains(searchTerm)...)
    
            //Create expression to represent x.[property1].Contains(searchTerm)
            var searchTermExpression = Expression.Constant(searchTerm);
    
    
            var param = stringProperties[0].Parameters.Single();
            Expression orExpression = null;
    
            //Build a contains expression for each property
            foreach (var stringProperty in stringProperties)
            {
                // re-write the property using the param we want to keep
                var body = SwapVisitor.Swap(stringProperty.Body, stringProperty.Parameters.Single(), param);
    
                var checkContainsExpression = Expression.Call(
                    body, typeof(string).GetMethod("Contains"), searchTermExpression);
    
                if (orExpression == null)
                {
                    orExpression = checkContainsExpression;
                }
                else
                {   // compose
                    orExpression = Expression.OrElse(orExpression, checkContainsExpression);
                }
            }
    
            var lambda = Expression.Lambda<Func<TSource, bool>>(orExpression, param);
            return source.Where(lambda);
        }
    }
