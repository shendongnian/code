    @foreach (var product in Model.Collection.Products.DistinctBy(p=>p.name))
---
    public static partial class MyExtensions
    {
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            return source.Where(x => knownKeys.Add(keySelector(x)));
        }
    }
