    jarray.Exec(item => item["property"] = "xx");
    public static class MyExtensions
    {
        public static void Exec<T>(this IEnumerable<T> list,Action<T> action)
        {
            if (list == null) return;
            foreach (var item in list)
                action(item);
        }
    }
