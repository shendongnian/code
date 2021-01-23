    public static class IEnumerableExtensions
    {
        public static void Action<T>(this IEnumerable<T> source, Action<T> sequenceElement, Action<T> lastElement)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (sequenceElement == null)
                throw new ArgumentNullException("sequenceElement");
            if (lastElement == null)
                throw new ArgumentNullException("lastElement");
            T element = default(T);
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                    element = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    sequenceElement(element);
                    element = enumerator.Current;
                }
                lastElement(element);
            }
        }
    }
