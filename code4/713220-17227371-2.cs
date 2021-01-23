    public static class EnumerableExtensions
    {
        public static string ToCommaSeparatedList(this IEnumerable enumerable)
        {
            var enumOfObjects = myEnumerable as IList<object> ?? myEnumerable.Cast<object>().ToList();
            var enumOfStrings = enumOfObjects.Select(x => x.ToString());
            return String.Join(",", enumOfStrings);
        }
    }
