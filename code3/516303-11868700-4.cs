    public static class TreeUtils {
        public static IEnumerable<T> GetAllNodes<T>(
            this T node
        ,   Func<T,IEnumerable<T>> f) 
        {
            return GetAllNodes(new[] {node}, f);
        }
        public static IEnumerable<T> GetAllNodes<T>(
            this IEnumerable<T> e
        ,   Func<T,IEnumerable<T>> f) 
        {
            return e.SelectMany(c => f(c).GetAllNodes(f)).Concat(e);
        }
    }
