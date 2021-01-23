    List<string> l = new []{"z","u","first","b","a"}
                         .OrderBy(s => s == "first").ToList();
    public static class Extensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, Predicate<T> firsts)
        {
            return source
              .Select(item => new { Item = item, Order = firsts(item) ? 0 : 1 })
              .OrderBy(a => a.Order)
              .ThenBy(a => a.Item)
              .Select(a => a.Item);
        }
    }
