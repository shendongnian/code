    public class OrderingCollection<TEntity> : IEnumerable {
        public void Add<TProperty>(Expression<Func<TEntity, TProperty>>) {
            ...
        }
    }
    public static IQueryable<T> Sort<T>(this IQueryable<T> entities, 
                                        OrderingCollection<T> o) where T : class {
        ...
    }
    q = q.Sort(new OrderingCollection { s => s.ProductName, s => s.OrderDate });
