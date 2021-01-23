    public static class JavaExtensions
    {
        public static IEnumerable ToEnumerable(Iterable iterable)
        {
            var iterator = iterable.iterator();
            while (iterator.hasNext())
            {
                yield return iterator.next();
            }
        }
    }
