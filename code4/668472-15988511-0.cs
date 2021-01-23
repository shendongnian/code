    public static class MyEnumerable
    {
        public static MyDbSet<T> ToMyDbSet<T>(this IEnumerable<T> source)
            where T : class
        {
            var collection = new MyDbSet<T>();
            foreach (var item in source)
                collection.Add(item);
            return collection;
        }
    }
