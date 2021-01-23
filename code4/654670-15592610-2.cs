    internal static class Program
    {
        public class Product
        {
            public string Name;
        }
        private static void Main(string[] args)
        {
            var searchStrings = new[] { "111", "222" };
            var cachedProductList = new List<Product>
            {
                new Product{Name = "111 should not match"},
                new Product{Name = "222 should not match"},
                new Product{Name = "111 222 should match"},
            };
            var filterExpressions = new List<Expression<Func<Product, bool>>>();
            foreach (string searchString in searchStrings)
            {
                Expression<Func<Product, bool>> containsExpression = x => x.Name.Contains(searchString); // NOT GOOD
                filterExpressions.Add(containsExpression);
            }
            var filters = CombinePredicates<Product>(filterExpressions, Expression.AndAlso);
            var query = cachedProductList.AsQueryable().Where(filters);
            var list = query.Take(10).ToList();
            foreach (var product in list)
            {
                Console.WriteLine(product.Name);
            }
        }
        public static Expression<Func<T, bool>> CombinePredicates<T>(IList<Expression<Func<T, bool>>> predicateExpressions, Func<Expression, Expression, BinaryExpression> logicalFunction)
        {
            Expression<Func<T, bool>> filter = null;
            if (predicateExpressions.Count > 0)
            {
                var firstPredicate = predicateExpressions[0];
                Expression body = firstPredicate.Body;
                for (int i = 1; i < predicateExpressions.Count; i++)
                {
                    body = logicalFunction(body, Expression.Invoke(predicateExpressions[i], firstPredicate.Parameters));
                }
                filter = Expression.Lambda<Func<T, bool>>(body, firstPredicate.Parameters);
            }
            return filter;
        }
    }
