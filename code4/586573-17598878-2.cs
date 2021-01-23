    public static class BatchLinq {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size) {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("size", "Must be greater than zero.");
            using (IEnumerator<T> enumerator = source.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return TakeIEnumerator(enumerator, size);
        }
        private static IEnumerable<T> TakeIEnumerator<T>(IEnumerator<T> source, int size) {
            int i = 0;
            do
                yield return source.Current;
            while (++i < size && source.MoveNext());
        }
	}
