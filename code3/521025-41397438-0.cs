     public class GridRequestSort
        {
            public string PropName { get; set; }
            public bool IsDescending { get; set; }
        }
    
            private static IQueryable<T> WrapSort<T>(
                IQueryable<T> query,
                GridRequestSort sort,
                bool isFirst = false)
            {
                var propAccessExpr = GetPropAccesssLambdaExpr(typeof(T), sort.PropName);
                var orderMethodName = "";
                if (isFirst)
                {
                    orderMethodName = sort.IsDescending ? "OrderByDescending" : "OrderBy";
                } 
                else
                {
                    orderMethodName = sort.IsDescending ? "ThenByDescending" : "ThenBy";
                }
    
                var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == orderMethodName && m.GetParameters().Length == 2);
                var genericMethod = method.MakeGenericMethod(typeof(T), propAccessExpr.ReturnType);
                var newQuery = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, propAccessExpr });
                return newQuery;
            }
    
            private static LambdaExpression GetPropAccesssLambdaExpr(Type type, string name)
            {
                var prop = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                var param = Expression.Parameter(type);
                var propAccess = Expression.Property(param, prop.Name);
                var expr = Expression.Lambda(propAccess, param);
                return expr;
            }
