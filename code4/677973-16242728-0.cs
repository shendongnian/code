    public static class PersonExtensionMethod
    {
        public static T SingleOrInstance<T>(this IEnumerable<T> source, Func<T, bool> precate)
        {
            var person = source.SingleOrDefault(precate);
            if (person == null)
                return (T)Activator.CreateInstance(typeof(T));
            return person;
        }
    }
