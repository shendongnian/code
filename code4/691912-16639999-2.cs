    public static class EnumerableHelper
    {
        public static IEnumerable<List<T>> GetWindows<T>(
            this IEnumerable<T> source,
            Func<T, bool> begin,
            Func<T, bool> end)
        {
            List<T> window = null;
            foreach (var item in source)
            {
                if (window == null && begin(item))
                {
                    window = new List<T>();
                }
                if (window != null)
                {
                    window.Add(item);
                }
                if (window != null && end(item))
                {
                    yield return window;
                    window = null;
                }
            }
        }
    };
