    class Program
    {
        static void Main(string[] args)
        {
            var input = new double[] { 1, 1.2, 1.1, 0.2, 1, 2, 3, 4 };
            var output = input.SkipWhileNext(T => T.IsIncreasing(), 2);
            Console.WriteLine(string.Format("{{ {0} }}", string.Join("; ", output)));
        }
    }
    public static class Extensions
    {
        public static bool IsIncreasing<T>(this IEnumerable<T> e) where T : IComparable<T>
        {
            T last = default(T);
            bool flag = false;
            foreach (T item in e)
            {
                if (flag)
                {
                    if (item.CompareTo(last) <= 0)
                    {
                        return false;
                    }
                }
                else
                {
                    flag = true;
                }
                last = item;
            }
            return true;
        }
        public static IEnumerable<T> SkipWhileNext<T>(this IEnumerable<T> e, Func<IEnumerable<T>, bool> predicate, int count)
        {
            count++;
            Queue<T> queue = new Queue<T>(count);
            foreach (T item in e)
            {
                queue.Enqueue(item);
                if (queue.Count == count)
                {
                    if (predicate(queue))
                    {
                        yield return queue.Dequeue();
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                }
            }
            while (queue.Count > 0)
            {
                yield return queue.Dequeue();
            }
        }
    }
