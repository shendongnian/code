        class Program
        {
            static void Main(string[] args)
            {
                List<string> list = new List<string>();
                list.Capacity = 4;
                var items = list.TakeOrDefault(4);
            }
        }
        public static class EnumerableExtensions
        {
            public static IEnumerable<T> TakeOrDefault<T>(this IEnumerable<T> enumerable, int length)
            {
                int count = 0;
                foreach (T element in enumerable)
                {
                    if (count == length)
                        yield break;
                    yield return element;
                    count++;
                }
                while (count != length)
                {
                    yield return default(T);
                    count++;
                }
            }
        }
