        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            List<T> batch = new List<T>();
            foreach (var item in source)
            {
                batch.Add(item);
                if (batch.Count >= size)
                {
                    yield return batch;
                    batch.Clear();
                }
            }
            if (batch.Count > 0)
            {
                yield return batch;
            }
        }
