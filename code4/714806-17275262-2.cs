    public static class SkipLastExtension
    {
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
        {
            var queue = new Queue<T>();
            foreach (var item in source)
            {
                queue.Enqueue(item);
                if (queue.Count > count)
                {
                    yield return queue.Dequeue();
                }
            }
        }
    }
