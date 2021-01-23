    public static class MyExtensions {
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source) {
            if (source is IList<T>) {
                var list = (IList<T>)source;
                for (int ix = list.Count - 1; ix >= 0; --ix) {
                    yield return list[ix];
                }
            }
            else {
                foreach (var item in Enumerable.Reverse(source)) {
                    yield return item;
                }
            }
        }
    }
